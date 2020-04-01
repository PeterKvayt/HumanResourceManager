using CommonClasses;
using DataAccessLayer.Interfaces;
using ExceptionClasses.Logers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccessLayer.DataContext
{
    /// <summary>
    /// Общая реализация классов DataAccessLayer
    /// </summary>
    /// <typeparam name="EntityType">Конкретный тип класса</typeparam>
    abstract class GeneralDataAccessLayer<EntityType> where EntityType : class, new()
    {
        /// <summary>
        /// Создает новую запись в базе данных
        /// </summary>
        /// <param name="parameters">Sql-параметры для создания новой записи</param>
        /// <param name="CREATE_STORED_PROCEDURE_NAME">Название хранимой процедуры</param>
        protected virtual void Create(IEnumerable<SqlParameter> parameters, string CREATE_STORED_PROCEDURE_NAME)
        {
            IDataBaseCommandExecutor storedProcedure = TryGetStoredProcedure(CREATE_STORED_PROCEDURE_NAME, parameters);

            try
            {
                storedProcedure.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                ExceptionLoger.Log(exception);

                throw;
            }
        }

        /// <summary>
        /// Обновляет запись в базе данных
        /// </summary>
        /// <param name="parameters">Sql-параметры для обновления записи</param>
        /// <param name="UPDATE_STORED_PROCEDURE_NAME">Название хранимой процедуры</param>
        protected virtual void Update(IEnumerable<SqlParameter> parameters, string UPDATE_STORED_PROCEDURE_NAME)
        {
            IDataBaseCommandExecutor storedProcedure = TryGetStoredProcedure(UPDATE_STORED_PROCEDURE_NAME, parameters);

            try
            {
                storedProcedure.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                ExceptionLoger.Log(exception);

                throw;
            }
        }

        /// <summary>
        /// Удаляет запись из базы данных
        /// </summary>
        /// <param name="id">Идентификатор удаляемой записи</param>
        /// <param name="DELETE_STORED_PROCEDURE_NAME">Название хранимой процедуры</param>
        protected virtual void Delete(IdType id, string DELETE_STORED_PROCEDURE_NAME)
        {
            IEnumerable<SqlParameter> storedProcedureParameters = GetIdParameters(id);

            IDataBaseCommandExecutor storedProcedure = TryGetStoredProcedure(DELETE_STORED_PROCEDURE_NAME, storedProcedureParameters);

            try
            {
                storedProcedure.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                ExceptionLoger.Log(exception);

                throw;
            }
        }

        /// <summary>
        /// Делегат для маппинга сущностей из базы данных
        /// </summary>
        /// <param name="reader">Reader с данными</param>
        /// <returns>Результирующий набор экземпляров класса EntityType</returns>
        protected delegate List<EntityType> Mapper(SqlDataReader reader);

        /// <summary>
        /// Возвращает набор экземпляров из базы данных
        /// </summary>
        /// <param name="STORED_PROCEDURE_NAME">Название хранимой процедуры</param>
        /// <param name="parameters">Параметры хранимой процедуры</param>
        /// <param name="MapMethod">Метод для маппинга данных в экземпляры класса EntityType</param>
        /// <returns></returns>
        protected List<EntityType> GetResultCollection(string STORED_PROCEDURE_NAME, IEnumerable<SqlParameter> parameters, Mapper MapMethod)
        {
            IDataBaseCommandExecutor storedProcedure = TryGetStoredProcedure(STORED_PROCEDURE_NAME, parameters);

            using (SqlConnection connection = storedProcedure.Connection)
            {
                connection.Open();

                SqlDataReader reader = storedProcedure.ExecuteReader();

                return MapMethod(reader);
            }
        }

        /// <summary>
        /// Успешный ответ базы данных
        /// </summary>
        private const int SUCCES_RESULT = 1;

        /// <summary>
        /// Проверяет существование записи в базе данных
        /// </summary>
        /// <param name="id">Идентификатор проверяемой записи</param>
        /// <param name="EXISTS_STORED_PROCEDURE_NAME">Название хранимой процедуры</param>
        /// <returns>Результат проверки</returns>
        protected virtual bool Exists(IdType id, string EXISTS_STORED_PROCEDURE_NAME)
        {
            IEnumerable<SqlParameter> storedProcedureParameters = GetIdParameters(id);

            IDataBaseCommandExecutor storedProcedure = TryGetStoredProcedure(EXISTS_STORED_PROCEDURE_NAME, storedProcedureParameters);

            try
            {
                int result = (int)storedProcedure.ExecuteScalar();

                return result == SUCCES_RESULT ? true : false;
            }
            catch (Exception exception)
            {
                ExceptionLoger.Log(exception);

                throw new Exception();
            }
        }

        /// <summary>
        /// Безопасно создает экземпляр хранимой процедуры
        /// </summary>
        /// <param name="storedProcedureName">Название хранимой процедуры</param>
        /// <param name="sqlParameters">Sql параметры хранимой процедуры</param>
        /// <returns>Хранимая процедура</returns>
        protected IDataBaseCommandExecutor TryGetStoredProcedure(string storedProcedureName, IEnumerable<SqlParameter> sqlParameters)
        {
            try
            {
                return new StoredProcedure(storedProcedureName, sqlParameters);
            }
            catch (Exception exception)
            {
                ExceptionLoger.Log(exception);

                throw;
            }
        }

        /// <summary>
        /// Создает идентифицирующие sql параметры
        /// </summary>
        /// <returns>Идентифицирующие параметры</returns>
        protected virtual List<SqlParameter> GetIdParameters(IdType id)
        {
            List<SqlParameter> idParameters = new List<SqlParameter>
            {
                new SqlParameter("@Id", id.ConvertToDBTypeId())
            };

            return idParameters;
        }

        /// <summary>
        /// Создает экземпляр класса IdType
        /// </summary>
        /// <param name="idObject">Id параметр SqlDataReader-а</param>
        /// <returns>Экземпляр класса IdType</returns>
        protected virtual IdType MapIdType(object idObject)
        {
            IdType id = new IdType
            {
                Identifier = Convert.ToUInt32(idObject)
            };

            return id;
        }
    }
}

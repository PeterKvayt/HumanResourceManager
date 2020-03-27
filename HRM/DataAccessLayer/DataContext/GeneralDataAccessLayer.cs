using CommonClasses;
using DataAccessLayer.Interfaces;
using ExceptionClasses.Logers;
using System;
using System.Collections.Generic;
using System.Data;
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
        public virtual void Create(IEnumerable<SqlParameter> parameters, string CREATE_STORED_PROCEDURE_NAME)
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
        public virtual void Update(IEnumerable<SqlParameter> parameters, string UPDATE_STORED_PROCEDURE_NAME)
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
        /// Возвращает конкретную запись в базе данных
        /// </summary>
        /// <param name="id">Идентификатор записи</param>
        /// <param name="GET_STORED_PROCEDURE_NAME">Название хранимой процедуры</param>
        /// <returns>Запрашиваемая запись</returns>
        protected virtual EntityType Get(IdType id, string GET_STORED_PROCEDURE_NAME)
        {
            IEnumerable<SqlParameter> storedProcedureParameters = GetIdParameters(id);

            IDataBaseCommandExecutor storedProcedure = TryGetStoredProcedure(GET_STORED_PROCEDURE_NAME, storedProcedureParameters);

            DataSet resultDataSet = null;

            try
            {
                resultDataSet = storedProcedure.Execute();
            }
            catch (Exception exception)
            {
                ExceptionLoger.Log(exception);

                throw;
            }

            if (resultDataSet != null)
            {
                DataTableMapper mapper = TryGetDataTableMapper(resultDataSet.Tables[0]);

                EntityType result = mapper.CreateObjectFromTable<EntityType>();

                return result;
            }
            else
            {
                const string EXCEPTION_MESSAGE = "Ошибка получения экземпляра класса из базы данных!";

                ExceptionLoger.Log(EXCEPTION_MESSAGE, typeof(GeneralDataAccessLayer<EntityType>).Name, "Get");

                throw new Exception();
            }
        }

        /// <summary>
        /// Возвращает все записи таблицы базы данных
        /// </summary>
        /// <param name="GET_ALL_STORED_PROCEDURE_NAME">Название хранимой процедуры</param>
        /// <returns>Список всех записей в таблице</returns>
        protected virtual IEnumerable<EntityType> GetAll(string GET_ALL_STORED_PROCEDURE_NAME)
        {
            IDataBaseCommandExecutor storedProcedure = TryGetStoredProcedure(GET_ALL_STORED_PROCEDURE_NAME, new List<SqlParameter> { });

            DataSet resultDataSet = null;
            try
            {
                resultDataSet = storedProcedure.Execute();
            }
            catch (Exception exception)
            {
                ExceptionLoger.Log(exception);

                throw;
            }

            if (resultDataSet != null)
            {
                DataTableMapper mapper = TryGetDataTableMapper(resultDataSet.Tables[0]);

                IEnumerable<EntityType> resultCollection = mapper.CreateListFromTable<EntityType>();

                return resultCollection;
            }
            else
            {
                string EXCEPTION_MESSAGE = $"Результат выполнения хранимой процедуры для получения всех записей класса {typeof(EntityType).ToString()} из базы данных вернул Null!";

                ExceptionLoger.Log(EXCEPTION_MESSAGE, typeof(GeneralDataAccessLayer<EntityType>).Name, "GetAll");

                throw new Exception();
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
        /// Безопасно создает экземпляр класса DataTableMapper
        /// </summary>
        /// <param name="dataTable">Контекст данных</param>
        /// <returns>Экземпляр класса DataTableMapper</returns>
        protected DataTableMapper TryGetDataTableMapper(DataTable dataTable)
        {
            try
            {
                return new DataTableMapper(dataTable);
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
    }
}

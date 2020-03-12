using CommonClasses;
using DataAccessLayer.Interfaces;
using ExceptionClasses.Loggers;
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
        public abstract void Create(EntityType newItem);

        public abstract void Update(EntityType item);

        protected virtual void Delete(IdType id, string DELETE_STORED_PROCEDURE_NAME)
        {
            IEnumerable<SqlParameter> storedProcedureParameters = GetIdParameters(id);

            IDataBaseCommandExecutor storedProcedure = TryGetStoredProcedure(DELETE_STORED_PROCEDURE_NAME, storedProcedureParameters);

            try
            {
                storedProcedure.ExecuteNonQuery();
            }
            catch (Exception)
            {
                string EXCEPTION_MESSAGE = $"Ошибка при удалении экземпляра класса {typeof(EntityType).ToString()}!";

                ExceptionLogger.LogError(EXCEPTION_MESSAGE);

                throw;
            }
        }

        protected virtual EntityType Get(IdType id, string GET_STORED_PROCEDURE_NAME)
        {
            IEnumerable<SqlParameter> storedProcedureParameters = GetIdParameters(id);

            IDataBaseCommandExecutor storedProcedure = TryGetStoredProcedure(GET_STORED_PROCEDURE_NAME, storedProcedureParameters);

            DataSet resultDataSet = null;

            try
            {
                resultDataSet = storedProcedure.Execute();
            }
            catch (Exception)
            {
                string EXCEPTION_MESSAGE = $"Ошибка выполнения хранимой процедуры получения экземпляра класса {typeof(EntityType).ToString()} из базы данных!";

                ExceptionLogger.LogError(EXCEPTION_MESSAGE);

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
                string EXCEPTION_MESSAGE = $"Ошибка получения экземпляра класса {typeof(EntityType).ToString()} из базы данных!";

                ExceptionLogger.LogError(EXCEPTION_MESSAGE);

                throw new Exception();
            }
        }

        protected virtual IEnumerable<EntityType> GetAll(string GET_ALL_STORED_PROCEDURE_NAME)
        {
            IDataBaseCommandExecutor storedProcedure = TryGetStoredProcedure(GET_ALL_STORED_PROCEDURE_NAME, new List<SqlParameter> { });

            DataSet resultDataSet = null;
            try
            {
                resultDataSet = storedProcedure.Execute();
            }
            catch (Exception)
            {
                string EXCEPTION_MESSAGE = $"Ошибка выполнения хранимой процедуры для получения всех записей класса {typeof(EntityType).ToString()} из базы данных!";

                ExceptionLogger.LogError(EXCEPTION_MESSAGE);

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

                ExceptionLogger.LogError(EXCEPTION_MESSAGE);

                throw new Exception();
            }
        }

        protected virtual bool Exists(IdType id, string EXISTS_STORED_PROCEDURE_NAME)
        {
            IEnumerable<SqlParameter> storedProcedureParameters = GetIdParameters(id);

            IDataBaseCommandExecutor storedProcedure = TryGetStoredProcedure(EXISTS_STORED_PROCEDURE_NAME, storedProcedureParameters);

            try
            {
                int result = (int)storedProcedure.ExecuteScalar();

                return result == 1 ? true : false;
            }
            catch (Exception ex)
            {
                string EXCEPTION_MESSAGE = $"Ошибка проверки существования записи экземпляра класса {typeof(EntityType).ToString()} в базе данных!";

                ExceptionLogger.LogError(EXCEPTION_MESSAGE);

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
            catch (Exception)
            {
                string EXCEPTION_MESSAGE = $"Ошибка создания хранимой процедуры в классе {typeof(EntityType).ToString()}DataAccessLayer!";

                ExceptionLogger.LogError(EXCEPTION_MESSAGE);

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
            catch (Exception)
            {
                string EXCEPTION_MESSAGE = $"Ошибка создания экземпляра класса DataTableMapper в классе {typeof(EntityType).ToString()}DataAccessLayer!";

                ExceptionLogger.LogError(EXCEPTION_MESSAGE);

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
                new SqlParameter("@Id", (int)id.Identificator)
            };

            return idParameters;
        }
    }
}

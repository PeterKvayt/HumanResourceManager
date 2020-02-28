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
    /// <typeparam name="T">Конкретный тип класса</typeparam>
    abstract class GeneralDataAccessLayer<T> where T : class, new()
    {
        public abstract void Create(T newItem);

        public abstract void Update(T item);

        protected virtual void Delete(IdType id, string DELETE_STORED_PROCEDURE_NAME)
        {
            List<SqlParameter> storedProcedureParameters = new List<SqlParameter>
            {
                new SqlParameter("@Id", id.Identificator)
            };

            IDataBaseCommandExecutor storedProcedure = TryGetStoredProcedure(DELETE_STORED_PROCEDURE_NAME, storedProcedureParameters);

            try
            {
                storedProcedure.ExecuteNonQuery();
            }
            catch (Exception)
            {
                string EXCEPTION_MESSAGE = $"Ошибка при удалении экземпляра класса {typeof(T).ToString()}!";

                ExceptionLogger.LogError(EXCEPTION_MESSAGE);

                throw;
            }
        }

        protected virtual T Get(IdType id, string GET_STORED_PROCEDURE_NAME)
        {
            IEnumerable<SqlParameter> storedProcedureParameters = new List<SqlParameter>
            {
                new SqlParameter("@Id", id.Identificator)
            };

            IDataBaseCommandExecutor storedProcedure = TryGetStoredProcedure(GET_STORED_PROCEDURE_NAME, storedProcedureParameters);

            DataSet resultDataSet = storedProcedure.Execute();

            if (resultDataSet != null)
            {
                DataTableMapper mapper = TryGetDataTableMapper(resultDataSet.Tables[0]);
                T result = mapper.CreateObjectFromTable<T>();

                return result;
            }
            else
            {
                string EXCEPTION_MESSAGE = $"Ошибка получения экземпляра класса {typeof(T).ToString()} из базы данных!";

                ExceptionLogger.LogError(EXCEPTION_MESSAGE);

                throw new Exception();
            }
        }

        protected virtual IEnumerable<T> GetAll(string GET_ALL_STORED_PROCEDURE_NAME)
        {
            IDataBaseCommandExecutor storedProcedure = TryGetStoredProcedure(GET_ALL_STORED_PROCEDURE_NAME, new List<SqlParameter> { });

            DataSet resultDataSet = null;
            try
            {
                resultDataSet = storedProcedure.Execute();
            }
            catch (Exception)
            {
                string EXCEPTION_MESSAGE = $"Ошибка выполнения хранимой процедуры для получения всех записей класса {typeof(T).ToString()} из базы данных!";

                ExceptionLogger.LogError(EXCEPTION_MESSAGE);

                throw;
            }

            if (resultDataSet != null)
            {
                DataTableMapper mapper = TryGetDataTableMapper(resultDataSet.Tables[0]);
                IEnumerable<T> resultCollection = mapper.CreateListFromTable<T>();

                return resultCollection;
            }
            else
            {
                string EXCEPTION_MESSAGE = $"Результат выполнения хранимой процедуры для получения всех записей класса {typeof(T).ToString()} из базы данных вернул Null!";

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
                string EXCEPTION_MESSAGE = $"Ошибка создания хранимой процедуры в классе {typeof(T).ToString()}DataAccessLayer!";

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
                string EXCEPTION_MESSAGE = $"Ошибка создания экземпляра класса DataTableMapper в классе {typeof(T).ToString()}DataAccessLayer!";

                ExceptionLogger.LogError(EXCEPTION_MESSAGE);

                throw;
            }
        }
    }
}

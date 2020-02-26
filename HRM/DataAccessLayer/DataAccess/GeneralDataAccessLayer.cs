using DataAccessLayer.AssistantClasses;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer.DataAccess
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

            IDataBaseExecutor storedProcedure = new StoredProcedure(DELETE_STORED_PROCEDURE_NAME, storedProcedureParameters);

            try
            {
                storedProcedure.ExecuteNonQuery();
            }
            catch (Exception)
            {
                // ToDo: exception
                throw;
            }
        }

        protected virtual T Get(IdType id, string GET_STORED_PROCEDURE_NAME)
        {
            IEnumerable<SqlParameter> storedProcedureParameters = new List<SqlParameter>
            {
                new SqlParameter("@Id", id.Identificator)
            };

            IDataBaseExecutor storedProcedure = new StoredProcedure(GET_STORED_PROCEDURE_NAME, storedProcedureParameters);

            DataSet resultDataSet = storedProcedure.Execute();

            if (resultDataSet != null)
            {
                DataTableMapper mapper = new DataTableMapper(resultDataSet.Tables[0]);

                T result = mapper.CreateObjectFromTable<T>();

                return result;
            }
            else
            {
                // ToDo: exception
                throw new ArgumentNullException();
            }
        }

        protected virtual IEnumerable<T> GetAll(string GET_ALL_STORED_PROCEDURE_NAME)
        {
            IDataBaseExecutor storedProcedure = new StoredProcedure(GET_ALL_STORED_PROCEDURE_NAME, new List<SqlParameter> { });

            DataSet resultDataSet = storedProcedure.Execute();

            if (resultDataSet != null)
            {
                DataTableMapper mapper = new DataTableMapper(resultDataSet.Tables[0]);

                IEnumerable<T> resultCollection = mapper.CreateListFromTable<T>();

                return resultCollection;
            }
            else
            {
                // ToDo: exception
                throw new ArgumentNullException();
            }
        }
    }
}

﻿using DataAccessLayer.AssistantClasses;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DataAccessLayer.DataAccess
{
    static class GeneralDataAccessLayer<T> where T : class, new()
    {
        public static void Delete(IdType id, string DELETE_STORED_PROCEDURE_NAME)
        {
            List<SqlParameter> storedProcedureParameters = new List<SqlParameter>
            {
                new SqlParameter("@Id", id.Identificator)
            };

            StoredProcedure storedProcedure = new StoredProcedure(DELETE_STORED_PROCEDURE_NAME, storedProcedureParameters);

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

        public static T Get(IdType id, string GET_STORED_PROCEDURE_NAME)
        {
            List<SqlParameter> storedProcedureParameters = new List<SqlParameter>
            {
                new SqlParameter("@Id", id.Identificator)
            };

            StoredProcedure storedProcedure = new StoredProcedure(GET_STORED_PROCEDURE_NAME, storedProcedureParameters);

            DataSet resultDataSet = storedProcedure.Execute();

            if (resultDataSet != null)
            {
                T result = DataTableMapper.CreateObjectFromTable<T>(resultDataSet.Tables[0]);

                return result;
            }
            else
            {
                // ToDo: exception
                throw new ArgumentNullException();
            }
        }

        public static IEnumerable<T> GetAll(string GET_ALL_STORED_PROCEDURE_NAME)
        {
            StoredProcedure storedProcedure = new StoredProcedure(GET_ALL_STORED_PROCEDURE_NAME, new List<SqlParameter> { });

            DataSet resultDataSet = storedProcedure.Execute();

            if (resultDataSet != null)
            {
                List<T> resultCollection = DataTableMapper.CreateListFromTable<T>(resultDataSet.Tables[0]);

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
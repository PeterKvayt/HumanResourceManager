﻿using CommonClasses;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using ExceptionClasses.Loggers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccessLayer.DataContext
{
    class LegalFormDataAccessLayer : GeneralDataAccessLayer<LegalForm>, IDataAccessLayer<LegalForm>
    {
        public override void Create(LegalForm newLegalForm)
        {
            IEnumerable<SqlParameter> storedProcedureParameters = new List<SqlParameter>
            {
                new SqlParameter("@Name", newLegalForm.Name)
            };

            const string CREATE_STORED_PROCEDURE_NAME = "spAddOrganizationalType";
            IDataBaseCommandExecutor storedProcedure = TryGetStoredProcedure(CREATE_STORED_PROCEDURE_NAME, storedProcedureParameters);

            try
            {
                storedProcedure.ExecuteNonQuery();
            }
            catch (Exception)
            {
                const string EXCEPTION_MESSAGE = "Ошибка создания экземпляра класса LegalForm в классе LegalFormDataAccessLayer!";

                ExceptionLogger.LogError(EXCEPTION_MESSAGE);

                throw;
            }
        }

        public override void Update(LegalForm legalForm)
        {
            IEnumerable<SqlParameter> storedProcedureParameters = new List<SqlParameter>
            {
                new SqlParameter("@Id", legalForm.Id.Identificator),
                new SqlParameter("@Name", legalForm.Name)
            };

            const string UPDATE_STORED_PROCEDURE_NAME = "spUpdateOrganizationalType";
            IDataBaseCommandExecutor storedProcedure = TryGetStoredProcedure(UPDATE_STORED_PROCEDURE_NAME, storedProcedureParameters);

            try
            {
                storedProcedure.ExecuteNonQuery();
            }
            catch (Exception)
            {
                const string EXCEPTION_MESSAGE = "Ошибка обновления экземпляра класса LegalForm в классе LegalFormDataAccessLayer!";

                ExceptionLogger.LogError(EXCEPTION_MESSAGE);

                throw;
            }
        }

        public void Delete(IdType id)
        {
            const string DELETE_STORED_PROCEDURE_NAME = "spDeleteOrganizationalType";
            Delete(id, DELETE_STORED_PROCEDURE_NAME);
        }

        public LegalForm Get(IdType id)
        {
            const string GET_STORED_PROCEDURE_NAME = "spGetOrganizationalType";
            return Get(id, GET_STORED_PROCEDURE_NAME);
        }

        public IEnumerable<LegalForm> GetAll()
        {
            const string GET_ALL_STORED_PROCEDURE_NAME = "spGetAllOrganizationalTypes";
            return GetAll(GET_ALL_STORED_PROCEDURE_NAME);
        }
    }
}

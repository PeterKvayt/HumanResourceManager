using DataAccessLayer.AssistantClasses;
using DataAccessLayer.DataAccess;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DataAccessLayer.DataContext
{
    class LegalFormDataAccessLayer : IDataAccessLayer<LegalForm>
    {
        public void Create(LegalForm newLegalForm)
        {
            List<SqlParameter> storedProcedureParameters = new List<SqlParameter>
            {
                new SqlParameter("@Name", newLegalForm.Name)
            };

            const string CREATE_STORED_PROCEDURE_NAME = "spAddOrganizationalType";
            StoredProcedure storedProcedure = new StoredProcedure(CREATE_STORED_PROCEDURE_NAME, storedProcedureParameters);

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

        public void Update(LegalForm legalForm)
        {
            List<SqlParameter> storedProcedureParameters = new List<SqlParameter>
            {
                new SqlParameter("@Id", legalForm.Id.Identificator),
                new SqlParameter("@Name", legalForm.Name)
            };

            const string UPDATE_STORED_PROCEDURE_NAME = "spUpdateOrganizationalType";
            StoredProcedure storedProcedure = new StoredProcedure(UPDATE_STORED_PROCEDURE_NAME, storedProcedureParameters);

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

        public void Delete(IdType id)
        {
            const string DELETE_STORED_PROCEDURE_NAME = "spDeleteOrganizationalType";
            GeneralDataAccessLayer<LegalForm>.Delete(id, DELETE_STORED_PROCEDURE_NAME);
        }

        public LegalForm Get(IdType id)
        {
            const string GET_STORED_PROCEDURE_NAME = "spGetOrganizationalType";
            return GeneralDataAccessLayer<LegalForm>.Get(id, GET_STORED_PROCEDURE_NAME);
        }

        public IEnumerable<LegalForm> GetAll()
        {
            const string GET_ALL_STORED_PROCEDURE_NAME = "spGetAllOrganizationalTypes";
            return GeneralDataAccessLayer<LegalForm>.GetAll(GET_ALL_STORED_PROCEDURE_NAME);
        }

        public IEnumerable<LegalForm> Find(Func<LegalForm, bool> predicate)
        {
            // ToDo: find
            throw new NotImplementedException();
        }
    }
}

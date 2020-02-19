using DataAccessLayer.Classes;
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
        private const string CREATE_STORED_PROCEDURE_NAME = "spAddOrganizationalType";
        public void Create(LegalForm newLegalForm)
        {
            List<SqlParameter> storedProcedureParameters = new List<SqlParameter>
            {
                new SqlParameter("@Name", newLegalForm.Name)
            };

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

        private const string DELETE_STORED_PROCEDURE_NAME = "spDeleteOrganizationalType";
        public void Delete(IdType id)
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

        private const string GET_STORED_PROCEDURE_NAME = "spGetOrganizationalType";
        public LegalForm Get(IdType id)
        {
            List<SqlParameter> storedProcedureParameters = new List<SqlParameter>
            {
                new SqlParameter("@Id", id.Identificator)
            };

            StoredProcedure storedProcedure = new StoredProcedure(GET_STORED_PROCEDURE_NAME, storedProcedureParameters);

            DataSet resultDataSet = storedProcedure.Execute();

            if (resultDataSet != null)
            {
                LegalForm resultLegalForm = DataTableMapper.CreateObjectFromTable<LegalForm>(resultDataSet.Tables[0]);

                return resultLegalForm;
            }
            else
            {
                // ToDo: exception
                throw new ArgumentNullException();
            }
        }

        private const string GET_ALL_STORED_PROCEDURE_NAME = "spGetAllOrganizationalTypes";
        public IEnumerable<LegalForm> GetAll()
        {
            StoredProcedure storedProcedure = new StoredProcedure(GET_ALL_STORED_PROCEDURE_NAME, new List<SqlParameter> { });

            DataSet resultDataSet = storedProcedure.Execute();

            if (resultDataSet != null)
            {
                List<LegalForm> legalFormCollection = DataTableMapper.CreateListFromTable<LegalForm>(resultDataSet.Tables[0]);

                return legalFormCollection;
            }
            else
            {
                // ToDo: exception
                throw new ArgumentNullException();
            }
        }

        private const string UPDATE_STORED_PROCEDURE_NAME = "spUpdateOrganizationalType";
        public void Update(LegalForm legalForm)
        {
            List<SqlParameter> storedProcedureParameters = new List<SqlParameter>
            {
                new SqlParameter("@Id", legalForm.Id.Identificator),
                new SqlParameter("@Name", legalForm.Name)
            };

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

        public IEnumerable<LegalForm> Find(Func<LegalForm, bool> predicate)
        {
            // ToDo: find
            throw new NotImplementedException();
        }
    }
}

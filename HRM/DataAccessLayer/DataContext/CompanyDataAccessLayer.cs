using DataAccessLayer.AssistantClasses;
using DataAccessLayer.DataAccess;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer.DataContext
{
    class CompanyDataAccessLayer : GeneralDataAccessLayer<Company>
    {
        private const string CREATE_STORED_PROCEDURE_NAME = "spAddCompany";
        public override void Create(Company newCompany)
        {
            List<SqlParameter> storedProcedureParameters = new List<SqlParameter>
            {
                new SqlParameter("@ActivityTypeId", newCompany.ActivityId.Identificator),
                new SqlParameter("@OrganizationalTypeId", newCompany.FormId.Identificator),
                new SqlParameter("@Name", newCompany.Name)
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

        private const string UPDATE_STORED_PROCEDURE_NAME = "spUpdateCompany";
        public override void Update(Company company)
        {
            List<SqlParameter> storedProcedureParameters = new List<SqlParameter>
            {
                new SqlParameter("@Id", company.Id.Identificator),
                new SqlParameter("@ActivityTypeId", company.ActivityId.Identificator),
                new SqlParameter("@OrganizationalTypeId", company.FormId.Identificator),
                new SqlParameter("@Name", company.Name)
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

        public void Delete(IdType id)
        {
            const string DELETE_STORED_PROCEDURE_NAME = "spDeleteCompany";

            Delete(id, DELETE_STORED_PROCEDURE_NAME);
        }

        public Company Get(IdType id)
        {
            const string GET_STORED_PROCEDURE_NAME = "spGetCompany";

            return Get(id, GET_STORED_PROCEDURE_NAME);
        }

        public IEnumerable<Company> GetAll()
        {
            const string GET_ALL_STORED_PROCEDURE_NAME = "spGetAllCompanies";

            return GetAll(GET_ALL_STORED_PROCEDURE_NAME);
        }

        public override IEnumerable<Company> Find(Func<Company, bool> predicate)
        {
            // ToDo: find
            throw new NotImplementedException();
        }
    }
}

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
    class CompanyDataAccessLayer : IDataAccessLayer<Company>
    {
        private const string CREATE_STORED_PROCEDURE_NAME = "spAddCompany";
        public void Create(Company newCompany)
        {
            List<SqlParameter> storedProcedureParameters = new List<SqlParameter>
            {
                new SqlParameter("@ActivityTypeId", newCompany.ActivityId),
                new SqlParameter("@OrganizationalTypeId", newCompany.FormId),
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

        private const string DELETE_STORED_PROCEDURE_NAME = "spDeleteCompany";
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

        private const string GET_STORED_PROCEDURE_NAME = "spGetCompany";
        public Company Get(IdType id)
        {
            List<SqlParameter> storedProcedureParameters = new List<SqlParameter>
            {
                new SqlParameter("@Id", id.Identificator)
            };

            StoredProcedure storedProcedure = new StoredProcedure(GET_STORED_PROCEDURE_NAME, storedProcedureParameters);

            DataSet resultDataSet = storedProcedure.Execute();

            if (resultDataSet != null)
            {
                Company resultCompany = DataTableMapper.CreateObjectFromTable<Company>(resultDataSet.Tables[0]);

                return resultCompany;
            }
            else
            {
                // ToDo: exception
                throw new ArgumentNullException();
            }
        }

        private const string GET_ALL_STORED_PROCEDURE_NAME = "spGetAllCompanies";
        public IEnumerable<Company> GetAll()
        {
            StoredProcedure storedProcedure = new StoredProcedure(GET_ALL_STORED_PROCEDURE_NAME, new List<SqlParameter> { });

            DataSet resultDataSet = storedProcedure.Execute();

            if (resultDataSet != null)
            {
                List<Company>  companyCollection = DataTableMapper.CreateListFromTable<Company>(resultDataSet.Tables[0]);

                return companyCollection;
            }
            else
            {
                // ToDo: exception
                throw new ArgumentNullException();
            }
        }

        private const string UPDATE_STORED_PROCEDURE_NAME = "spUpdateCompany";
        public void Update(Company company)
        {
            List<SqlParameter> storedProcedureParameters = new List<SqlParameter>
            {
                new SqlParameter("@Id", company.Id),
                new SqlParameter("@ActivityTypeId", company.ActivityId),
                new SqlParameter("@OrganizationalTypeId", company.FormId),
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

        public IEnumerable<Company> Find(Func<Company, bool> predicate)
        {
            // ToDo: find
            throw new NotImplementedException();
        }
    }
}

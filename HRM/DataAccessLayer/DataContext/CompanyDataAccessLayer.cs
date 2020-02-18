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
        private const string CREATE_STORED_PROCEDURE = "spAddCompany";
        public void Create(Company newCompany)
        {
            List<SqlParameter> storedProcedureParameters = new List<SqlParameter>
            {
                new SqlParameter("@ActivityTypeId", newCompany.Activity.Id),
                new SqlParameter("@OrganizationalTypeId", newCompany.Form.Id),
                new SqlParameter("@Name", newCompany.Name)
            };

            StoredProcedure storedProcedure = new StoredProcedure(CREATE_STORED_PROCEDURE, storedProcedureParameters);

            try
            {
                storedProcedure.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private const string DELETE_STORED_PROCEDURE = "spDeleteCompany";
        public void Delete(IdType id)
        {
            List<SqlParameter> storedProcedureParameters = new List<SqlParameter>
            {
                new SqlParameter("@Id", id.Identificator)
            };

            StoredProcedure storedProcedure = new StoredProcedure(DELETE_STORED_PROCEDURE, storedProcedureParameters);

            try
            {
                storedProcedure.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private const string GET_STORED_PROCEDURE = "spGetCompany";
        public Company Get(IdType id)
        {
            List<SqlParameter> storedProcedureParameters = new List<SqlParameter>
            {
                new SqlParameter("@Id", id.Identificator)
            };

            StoredProcedure storedProcedure = new StoredProcedure(GET_STORED_PROCEDURE, storedProcedureParameters);

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

        private const string GET_ALL_STORED_PROCEDURE = "spGetAllCompanies";
        public IEnumerable<Company> GetAll()
        {
            StoredProcedure storedProcedure = new StoredProcedure(GET_ALL_STORED_PROCEDURE, new List<SqlParameter> { });

            DataSet resultDataSet = storedProcedure.Execute();

            if (resultDataSet != null)
            {
                List<Company>  companyCollection = DataTableMapper.CreateListFromTable<Company>(resultDataSet.Tables[0]);

                return companyCollection;
            }
            else
            {
                // ToDo: exp
                throw new ArgumentNullException();
            }
        }

        private const string UPDATE_STORED_PROCEDURE = "spUpdateCompany";
        public void Update(Company company)
        {
            List<SqlParameter> storedProcedureParameters = new List<SqlParameter>
            {
                new SqlParameter("@Id", company.Id),
                new SqlParameter("@ActivityTypeId", company.ActivityId),
                new SqlParameter("@OrganizationalTypeId", company.FormId),
                new SqlParameter("@Name", company.Name)
            };

            StoredProcedure storedProcedure = new StoredProcedure(UPDATE_STORED_PROCEDURE, storedProcedureParameters);

            try
            {
                storedProcedure.ExecuteNonQuery();
            }
            catch (Exception)
            {
                // ToDo: exp
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

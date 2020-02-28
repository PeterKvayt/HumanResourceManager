﻿using CommonClasses;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using ExceptionClasses.Loggers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccessLayer.DataContext
{
    class CompanyDataAccessLayer : GeneralDataAccessLayer<Company>, IDataAccessLayer<Company>
    {
        public override void Create(Company newCompany)
        {
            IEnumerable<SqlParameter> storedProcedureParameters = new List<SqlParameter>
            {
                new SqlParameter("@ActivityTypeId", newCompany.ActivityId.Identificator),
                new SqlParameter("@OrganizationalTypeId", newCompany.LegalFormId.Identificator),
                new SqlParameter("@Name", newCompany.Name)
            };

            const string CREATE_STORED_PROCEDURE_NAME = "spAddCompany";
            IDataBaseExecutor storedProcedure = TryGetStoredProcedure(CREATE_STORED_PROCEDURE_NAME, storedProcedureParameters);

            try
            {
                storedProcedure.ExecuteNonQuery();
            }
            catch (Exception)
            {
                const string EXCEPTION_MESSAGE = "Ошибка создания экземпляра класса Company в классе CompanyDataAccessLayer!";

                ExceptionLogger.LogError(EXCEPTION_MESSAGE);

                throw;
            }
        }

        public override void Update(Company company)
        {
            IEnumerable<SqlParameter> storedProcedureParameters = new List<SqlParameter>
            {
                new SqlParameter("@Id", company.Id.Identificator),
                new SqlParameter("@ActivityTypeId", company.ActivityId.Identificator),
                new SqlParameter("@OrganizationalTypeId", company.LegalFormId.Identificator),
                new SqlParameter("@Name", company.Name)
            };

            const string UPDATE_STORED_PROCEDURE_NAME = "spUpdateCompany";
            IDataBaseExecutor storedProcedure = TryGetStoredProcedure(UPDATE_STORED_PROCEDURE_NAME, storedProcedureParameters);

            try
            {
                storedProcedure.ExecuteNonQuery();
            }
            catch (Exception)
            {
                const string EXCEPTION_MESSAGE = "Ошибка обновления экземпляра класса Company в классе CompanyDataAccessLayer!";

                ExceptionLogger.LogError(EXCEPTION_MESSAGE);

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
    }
}

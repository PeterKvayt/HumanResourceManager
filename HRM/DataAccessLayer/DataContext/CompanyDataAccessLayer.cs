using CommonClasses;
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

        /// <summary>
        /// Инициализирует параметры для создания записи в базе данных
        /// </summary>
        /// <param name="item">Экземпляр класса, который необходимо создать в базе данных</param>
        /// <returns>Список sql параметров для выполнения хранимой процедуры</returns>
        private List<SqlParameter> GetParametersForCreate(Company item)
        {
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@ActivityTypeId", item.ActivityId.Identificator),
                new SqlParameter("@LegalFormId", item.LegalFormId.Identificator),
                new SqlParameter("@Name", item.Name)
            };

            return parameters;
        }

        public override void Create(Company newCompany)
        {
            IEnumerable<SqlParameter> parameters = GetParametersForCreate(newCompany);

            const string CREATE_STORED_PROCEDURE_NAME = "spAddCompany";

            IDataBaseCommandExecutor storedProcedure = TryGetStoredProcedure(CREATE_STORED_PROCEDURE_NAME, parameters);

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

        /// <summary>
        /// Инициализирует параметры для обновления записи в базе данных
        /// </summary>
        /// <param name="item">Экземпляр класса, который необходимо обновить в базе данных</param>
        /// <returns>Список sql параметров для выполнения хранимой процедуры</returns>
        private List<SqlParameter> GetParametersForUpdate(Company item)
        {
            SqlParameter idParameter = new SqlParameter("@Id", item.Id.Identificator);

            List<SqlParameter> parameters = GetParametersForCreate(item);
            parameters.Add(idParameter);

            return parameters;
        }

        public override void Update(Company company)
        {
            IEnumerable<SqlParameter> parameters = GetParametersForUpdate(company);

            const string UPDATE_STORED_PROCEDURE_NAME = "spUpdateCompany";

            IDataBaseCommandExecutor storedProcedure = TryGetStoredProcedure(UPDATE_STORED_PROCEDURE_NAME, parameters);

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

        public bool Exists(IdType id)
        {
            const string EXISTS_STORED_PROCEDURE_NAME = "spExistsCompany";
            return Exists(id, EXISTS_STORED_PROCEDURE_NAME);
        }
    }
}

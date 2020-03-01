using CommonClasses;
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
        /// <summary>
        /// Инициализирует параметры для создания записи в базе данных
        /// </summary>
        /// <param name="item">Экземпляр класса, который необходимо создать в базе данных</param>
        /// <returns>Список sql параметров для выполнения хранимой процедуры</returns>
        private List<SqlParameter> GetParametersForCreate(LegalForm item)
        {
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                 new SqlParameter("@Name", item.Name)
            };

            return parameters;
        }

        public override void Create(LegalForm newLegalForm)
        {
            IEnumerable<SqlParameter> parameters = GetParametersForCreate(newLegalForm);

            const string CREATE_STORED_PROCEDURE_NAME = "spAddOrganizationalType";

            IDataBaseCommandExecutor storedProcedure = TryGetStoredProcedure(CREATE_STORED_PROCEDURE_NAME, parameters);

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

        /// <summary>
        /// Инициализирует параметры для обновления записи в базе данных
        /// </summary>
        /// <param name="item">Экземпляр класса, который необходимо обновить в базе данных</param>
        /// <returns>Список sql параметров для выполнения хранимой процедуры</returns>
        private List<SqlParameter> GetParametersForUpdate(LegalForm item)
        {
            SqlParameter idParameter = new SqlParameter("@Id", item.Id.Identificator);

            List<SqlParameter> parameters = GetParametersForCreate(item);
            parameters.Add(idParameter);

            return parameters;
        }

        public override void Update(LegalForm legalForm)
        {
            IEnumerable<SqlParameter> parameters = GetParametersForUpdate(legalForm);

            const string UPDATE_STORED_PROCEDURE_NAME = "spUpdateOrganizationalType";

            IDataBaseCommandExecutor storedProcedure = TryGetStoredProcedure(UPDATE_STORED_PROCEDURE_NAME, parameters);

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

        public bool Exists(IdType id)
        {
            const string EXISTS_STORED_PROCEDURE_NAME = "spIsLegalFormExist";
            return Exists(id, EXISTS_STORED_PROCEDURE_NAME);
        }
    }
}

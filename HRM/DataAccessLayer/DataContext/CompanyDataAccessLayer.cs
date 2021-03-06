﻿using CommonClasses;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using ExceptionClasses.Logers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccessLayer.DataContext
{
    class CompanyDataAccessLayer : GeneralDataAccessLayer<Company>, ICompanyDataAccessLayer<Company>
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
                new SqlParameter("@ActivityTypeId", item.ActivityTypeId.ConvertToDBTypeId()),
                new SqlParameter("@LegalFormId",  item.LegalFormId.ConvertToDBTypeId()),
                new SqlParameter("@Name", item.Name)
            };

            return parameters;
        }

        /// <summary>
        /// Создает новую запись в базе данных
        /// </summary>
        /// <param name="item">Новый экземпляр класса</param>
        public void Create(Company newCompany)
        {
            IEnumerable<SqlParameter> parameters = GetParametersForCreate(newCompany);

            const string CREATE_STORED_PROCEDURE_NAME = "spAddCompany";

            Create(parameters, CREATE_STORED_PROCEDURE_NAME);
        }

        /// <summary>
        /// Инициализирует параметры для обновления записи в базе данных
        /// </summary>
        /// <param name="item">Экземпляр класса, который необходимо обновить в базе данных</param>
        /// <returns>Список sql параметров для выполнения хранимой процедуры</returns>
        private List<SqlParameter> GetParametersForUpdate(Company item)
        {
            List<SqlParameter> idParameter = GetIdParameters(item.Id);

            List<SqlParameter> parameters = GetParametersForCreate(item);
            foreach (var idParam in idParameter)
            {
                parameters.Add(idParam);
            }

            return parameters;
        }

        /// <summary>
        /// Обновляет запись в базе данных
        /// </summary>
        /// <param name="item">Экземпляр класса, который необходимо обновить</param>
        public void Update(Company company)
        {
            IEnumerable<SqlParameter> parameters = GetParametersForUpdate(company);

            const string UPDATE_STORED_PROCEDURE_NAME = "spUpdateCompany";

            Update(parameters, UPDATE_STORED_PROCEDURE_NAME);
        }

        /// <summary>
        /// Запрашивает размер компании из базы данных
        /// </summary>
        /// <param name="company">Компания, для которой ищем размер</param>
        /// <returns>Размер компании</returns>
        public int GetSize(Company company)
        {
            IEnumerable<SqlParameter> parameters = GetIdParameters(company.Id);

            const string GET_SIZE_PROCEDURE_NAME = "spGetCompanySize";

            IDataBaseCommandExecutor storedProcedure = TryGetStoredProcedure(GET_SIZE_PROCEDURE_NAME, parameters);

            try
            {
                return Convert.ToInt32( storedProcedure.ExecuteScalar() );
            }
            catch (Exception exception)
            {
                ExceptionLoger.Log(exception);

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

            IEnumerable<SqlParameter> parameters = GetIdParameters(id);

            return GetResultCollection(GET_STORED_PROCEDURE_NAME, parameters, MapCollection)[0];
        }

        public IEnumerable<Company> GetAll()
        {
            const string GET_ALL_STORED_PROCEDURE_NAME = "spGetAllCompanies";

            return GetResultCollection(GET_ALL_STORED_PROCEDURE_NAME, new List<SqlParameter> { }, MapCollection);
        }

        /// <summary>
        /// Создает все сущности из базы данных
        /// </summary>
        /// <param name="reader">Ридер, содержащий все записи из базы данных</param>
        /// <returns>Все сущности из базы данных</returns>
        private List<Company> MapCollection(SqlDataReader reader)
        {
            var resultCollection = new List<Company> { };

            while (reader.Read())
            {
                var company = new Company
                {
                    Id = MapIdType(reader["Id"]),
                    LegalFormId = MapIdType(reader["LegalFormId"]),
                    ActivityTypeId = MapIdType(reader["ActivityTypeId"]),
                    Name = reader["Name"].ToString()
                };

                resultCollection.Add(company);
            }

            return resultCollection;
        }

        public bool Exists(IdType id)
        {
            const string EXISTS_STORED_PROCEDURE_NAME = "spExistsCompany";
            return Exists(id, EXISTS_STORED_PROCEDURE_NAME);
        }
    }
}

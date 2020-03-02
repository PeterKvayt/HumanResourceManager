using CommonClasses;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using ExceptionClasses.Loggers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccessLayer.DataContext
{
    class EmployeeDataAccessLayer : GeneralDataAccessLayer<Employee>, IDataAccessLayer<Employee>
    {
        /// <summary>
        /// Инициализирует параметры для создания записи в базе данных
        /// </summary>
        /// <param name="item">Экземпляр класса, который необходимо создать в базе данных</param>
        /// <returns>Список sql параметров для выполнения хранимой процедуры</returns>
        private List<SqlParameter> GetParametersForCreate(Employee item)
        {
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@PositionId", item.PositionId.Identificator),
                new SqlParameter("@CompanyId", item.CompanyId.Identificator),
                new SqlParameter("@Surname", item.BigName.Surname),
                new SqlParameter("@MiddleName", item.BigName.Middlename),
                new SqlParameter("@Name", item.BigName.Name),
                new SqlParameter("@DateOfEmployment", item.DateOfEmployment)
            };

            return parameters;
        }

        public override void Create(Employee item)
        {
            IEnumerable<SqlParameter> parameters = GetParametersForCreate(item);

            const string CREATE_STORED_PROCEDURE_NAME = "spAddEmployee";

            IDataBaseCommandExecutor storedProcedure = TryGetStoredProcedure(CREATE_STORED_PROCEDURE_NAME, parameters);

            try
            {
                storedProcedure.ExecuteNonQuery();
            }
            catch (Exception)
            {
                const string EXCEPTION_MESSAGE = "Ошибка создания экземпляра класса Employee в классе EmployeeDataAccessLayer!";

                ExceptionLogger.LogError(EXCEPTION_MESSAGE);

                throw;
            }
        }

        /// <summary>
        /// Инициализирует параметры для обновления записи в базе данных
        /// </summary>
        /// <param name="item">Экземпляр класса, который необходимо обновить в базе данных</param>
        /// <returns>Список sql параметров для выполнения хранимой процедуры</returns>
        private List<SqlParameter> GetParametersForUpdate(Employee item)
        {
            SqlParameter idParameter = new SqlParameter("@Id", item.Id.Identificator);

            List<SqlParameter> parameters = GetParametersForCreate(item);
            parameters.Add(idParameter);

            return parameters;
        }

        public override void Update(Employee item)
        {
            IEnumerable<SqlParameter> parameters = GetParametersForUpdate(item);

            const string UPDATE_STORED_PROCEDURE_NAME = "spUpdateEmployee";

            IDataBaseCommandExecutor storedProcedure = TryGetStoredProcedure(UPDATE_STORED_PROCEDURE_NAME, parameters);

            try
            {
                storedProcedure.ExecuteNonQuery();
            }
            catch (Exception)
            {
                const string EXCEPTION_MESSAGE = "Ошибка обновления экземпляра класса Employee в классе EmployeeDataAccessLayer!";

                ExceptionLogger.LogError(EXCEPTION_MESSAGE);

                throw;
            }
        }

        public void Delete(Employee item)
        {
            const string DELETE_STORED_PROCEDURE_NAME = "spDeleteEmployee";
            Delete(item.Id, DELETE_STORED_PROCEDURE_NAME);
        }

        public Employee Get(Employee item)
        {
            const string GET_STORED_PROCEDURE_NAME = "spGetEmployee";
            return Get(item.Id, GET_STORED_PROCEDURE_NAME);
        }

        public IEnumerable<Employee> GetAll()
        {
            const string GET_ALL_STORED_PROCEDURE_NAME = "spGetAllEmployees";
            return GetAll(GET_ALL_STORED_PROCEDURE_NAME);
        }

        public bool Exists(Employee item)
        {
            const string EXISTS_STORED_PROCEDURE_NAME = "spExistsEmployee";
            return Exists(item.Id, EXISTS_STORED_PROCEDURE_NAME);
        }
    }
}

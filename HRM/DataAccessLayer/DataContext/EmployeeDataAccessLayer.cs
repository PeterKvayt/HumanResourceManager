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
                new SqlParameter("@PositionId",  item.PositionId.ConvertToDBTypeId()),
                new SqlParameter("@CompanyId",  item.CompanyId.ConvertToDBTypeId()),
                new SqlParameter("@Surname", item.Surname),
                new SqlParameter("@MiddleName", item.MiddleName),
                new SqlParameter("@Name", item.Name),
                new SqlParameter("@DateOfEmployment", item.DateOfEmployment)
            };

            return parameters;
        }

        /// <summary>
        /// Создает новую запись в базе данных
        /// </summary>
        /// <param name="item">Новый экземпляр класса</param>
        public override void Create(Employee newEmployee)
        {
            IEnumerable<SqlParameter> parameters = GetParametersForCreate(newEmployee);

            const string CREATE_STORED_PROCEDURE_NAME = "spAddEmployee";

            IDataBaseCommandExecutor storedProcedure = TryGetStoredProcedure(CREATE_STORED_PROCEDURE_NAME, parameters);

            try
            {
                storedProcedure.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                ExceptionLogger.Log(exception);

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
        public override void Update(Employee employee)
        {
            IEnumerable<SqlParameter> parameters = GetParametersForUpdate(employee);

            const string UPDATE_STORED_PROCEDURE_NAME = "spUpdateEmployee";

            IDataBaseCommandExecutor storedProcedure = TryGetStoredProcedure(UPDATE_STORED_PROCEDURE_NAME, parameters);

            try
            {
                storedProcedure.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                ExceptionLogger.Log(exception);

                throw;
            }
        }

        public void Delete(IdType id)
        {
            const string DELETE_STORED_PROCEDURE_NAME = "spDeleteEmployee";
            Delete(id, DELETE_STORED_PROCEDURE_NAME);
        }

        public Employee Get(IdType id)
        {
            const string GET_STORED_PROCEDURE_NAME = "spGetEmployee";
            return Get(id, GET_STORED_PROCEDURE_NAME);
        }

        public IEnumerable<Employee> GetAll()
        {
            const string GET_ALL_STORED_PROCEDURE_NAME = "spGetAllEmployees";
            return GetAll(GET_ALL_STORED_PROCEDURE_NAME);
        }

        public bool Exists(IdType id)
        {
            const string EXISTS_STORED_PROCEDURE_NAME = "spExistsEmployee";
            return Exists(id, EXISTS_STORED_PROCEDURE_NAME);
        }
    }
}

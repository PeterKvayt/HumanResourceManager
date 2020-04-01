using CommonClasses;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
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
        public void Create(Employee newEmployee)
        {
            IEnumerable<SqlParameter> parameters = GetParametersForCreate(newEmployee);

            const string CREATE_STORED_PROCEDURE_NAME = "spAddEmployee";

            Create(parameters, CREATE_STORED_PROCEDURE_NAME);
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
        public void Update(Employee employee)
        {
            IEnumerable<SqlParameter> parameters = GetParametersForUpdate(employee);

            const string UPDATE_STORED_PROCEDURE_NAME = "spUpdateEmployee";

            Update(parameters, UPDATE_STORED_PROCEDURE_NAME);

        }

        public void Delete(IdType id)
        {
            const string DELETE_STORED_PROCEDURE_NAME = "spDeleteEmployee";
            Delete(id, DELETE_STORED_PROCEDURE_NAME);
        }

        public Employee Get(IdType id)
        {
            const string GET_STORED_PROCEDURE_NAME = "spGetEmployee";

            IEnumerable<SqlParameter> parameters = GetIdParameters(id);

            return GetResultCollection(GET_STORED_PROCEDURE_NAME, parameters, MapCollection)[0];
        }

        public IEnumerable<Employee> GetAll()
        {
            const string GET_ALL_STORED_PROCEDURE_NAME = "spGetAllEmployees";

            return GetResultCollection(GET_ALL_STORED_PROCEDURE_NAME, new List<SqlParameter> { }, MapCollection);
        }

        /// <summary>
        /// Создает все сущности из базы данных
        /// </summary>
        /// <param name="reader">Ридер, содержащий все записи из базы данных</param>
        /// <returns>Все сущности из базы данных</returns>
        private List<Employee> MapCollection(SqlDataReader reader)
        {
            var resultCollection = new List<Employee> { };

            while (reader.Read())
            {
                var employee = new Employee
                {
                    Id = MapIdType(reader["Id"]),
                    PositionId = MapIdType(reader["PositionId"]),
                    CompanyId = MapIdType(reader["CompanyId"]),
                    Name = reader["Name"].ToString(),
                    Surname = reader["Surname"].ToString(),
                    MiddleName = reader["MiddleName"].ToString(),
                    DateOfEmployment = Convert.ToDateTime(reader["DateOfEmployment"])
                };

                resultCollection.Add(employee);
            }

            return resultCollection;
        }

        public bool Exists(IdType id)
        {
            const string EXISTS_STORED_PROCEDURE_NAME = "spExistsEmployee";
            return Exists(id, EXISTS_STORED_PROCEDURE_NAME);
        }
    }
}

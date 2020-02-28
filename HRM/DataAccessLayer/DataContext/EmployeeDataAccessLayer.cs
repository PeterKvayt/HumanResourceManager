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
        public override void Create(Employee newEmployee)
        {
            IEnumerable<SqlParameter> storedProcedureParameters = new List<SqlParameter>
            {
                new SqlParameter("@PositionId", newEmployee.PositionId.Identificator),
                new SqlParameter("@CompanyId", newEmployee.CompanyId.Identificator),
                new SqlParameter("@Surname", newEmployee.BigName.Surname),
                new SqlParameter("@MiddleName", newEmployee.BigName.Middlename),
                new SqlParameter("@Name", newEmployee.BigName.Name),
                new SqlParameter("@DateOfEmployment", newEmployee.DateOfEmployment)
            };

            const string CREATE_STORED_PROCEDURE_NAME = "spAddEmployee";
            IDataBaseCommandExecutor storedProcedure = TryGetStoredProcedure(CREATE_STORED_PROCEDURE_NAME, storedProcedureParameters);

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

        public override void Update(Employee newEmployee)
        {
            IEnumerable<SqlParameter> storedProcedureParameters = new List<SqlParameter>
            {
                new SqlParameter("@Id", newEmployee.Id.Identificator),
                new SqlParameter("@PositionId", newEmployee.PositionId.Identificator),
                new SqlParameter("@CompanyId", newEmployee.CompanyId.Identificator),
                new SqlParameter("@Surname", newEmployee.BigName.Surname),
                new SqlParameter("@MiddleName", newEmployee.BigName.Middlename),
                new SqlParameter("@Name", newEmployee.BigName.Name),
                new SqlParameter("@DateOfEmployment", newEmployee.DateOfEmployment)
            };

            const string UPDATE_STORED_PROCEDURE_NAME = "spUpdateEmployee";
            IDataBaseCommandExecutor storedProcedure = TryGetStoredProcedure(UPDATE_STORED_PROCEDURE_NAME, storedProcedureParameters);

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
    }
}

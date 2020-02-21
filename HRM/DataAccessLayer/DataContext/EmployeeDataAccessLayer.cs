using DataAccessLayer.AssistantClasses;
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
    class EmployeeDataAccessLayer : IDataAccessLayer<Employee>
    {
        public void Create(Employee newEmployee)
        {
            List<SqlParameter> storedProcedureParameters = new List<SqlParameter>
            {
                new SqlParameter("@PositionId", newEmployee.PositionId.Identificator),
                new SqlParameter("@CompanyId", newEmployee.CompanyId.Identificator),
                new SqlParameter("@Surname", newEmployee.BigName.Surname),
                new SqlParameter("@MiddleName", newEmployee.BigName.Middlename),
                new SqlParameter("@Name", newEmployee.BigName.Name),
                new SqlParameter("@DateOfEmployment", newEmployee.DateOfEmployment)
            };

            const string CREATE_STORED_PROCEDURE_NAME = "spAddEmployee";
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

        public void Update(Employee newEmployee)
        {
            List<SqlParameter> storedProcedureParameters = new List<SqlParameter>
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

        public void Delete(IdType id)
        {
            const string DELETE_STORED_PROCEDURE_NAME = "spDeleteEmployee";
            GeneralDataAccessLayer<Employee>.Delete(id, DELETE_STORED_PROCEDURE_NAME);
        }

        public Employee Get(IdType id)
        {
            const string GET_STORED_PROCEDURE_NAME = "spGetEmployee";
            return GeneralDataAccessLayer<Employee>.Get(id, GET_STORED_PROCEDURE_NAME);
        }

        public IEnumerable<Employee> GetAll()
        {
            const string GET_ALL_STORED_PROCEDURE_NAME = "spGetAllEmployees";
            return GeneralDataAccessLayer<Employee>.GetAll(GET_ALL_STORED_PROCEDURE_NAME);
        }

        public IEnumerable<Employee> Find(Func<Employee, bool> predicate)
        {
            // ToDo: find
            throw new NotImplementedException();
        }
    }
}

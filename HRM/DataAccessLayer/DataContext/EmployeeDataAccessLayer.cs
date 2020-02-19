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
    class EmployeeDataAccessLayer : IDataAccessLayer<Employee>
    {
        private const string CREATE_STORED_PROCEDURE_NAME = "spAddEmployee";
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

        private const string DELETE_STORED_PROCEDURE_NAME = "spDeleteEmployee";
        public void Delete(IdType id)
        {
            List<SqlParameter> storedProcedureParameters = new List<SqlParameter>
            {
                new SqlParameter("@Id", id.Identificator)
            };

            StoredProcedure storedProcedure = new StoredProcedure(DELETE_STORED_PROCEDURE_NAME, storedProcedureParameters);

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

        private const string GET_STORED_PROCEDURE_NAME = "spGetEmployee";
        public Employee Get(IdType id)
        {
            List<SqlParameter> storedProcedureParameters = new List<SqlParameter>
            {
                new SqlParameter("@Id", id.Identificator)
            };

            StoredProcedure storedProcedure = new StoredProcedure(GET_STORED_PROCEDURE_NAME, storedProcedureParameters);

            DataSet resultDataSet = storedProcedure.Execute();

            if (resultDataSet != null)
            {
                Employee resultEmployee = DataTableMapper.CreateObjectFromTable<Employee>(resultDataSet.Tables[0]);

                return resultEmployee;
            }
            else
            {
                // ToDo: exception
                throw new ArgumentNullException();
            }
        }

        private const string GET_ALL_STORED_PROCEDURE_NAME = "spGetAllEmployees";
        public IEnumerable<Employee> GetAll()
        {
            StoredProcedure storedProcedure = new StoredProcedure(GET_ALL_STORED_PROCEDURE_NAME, new List<SqlParameter> { });

            DataSet resultDataSet = storedProcedure.Execute();

            if (resultDataSet != null)
            {
                IEnumerable<Employee> employeeCollection = DataTableMapper.CreateListFromTable<Employee>(resultDataSet.Tables[0]);

                return employeeCollection;
            }
            else
            {
                // ToDo: exception
                throw new ArgumentNullException();
            }
        }

        private const string UPDATE_STORED_PROCEDURE_NAME = "spUpdateEmployee";
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

        public IEnumerable<Employee> Find(Func<Employee, bool> predicate)
        {
            // ToDo: find
            throw new NotImplementedException();
        }
    }
}

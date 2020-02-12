using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using HumanResourceManager.DataBaseEntranceLayer;
using HumanResourceManager.Models;

namespace HumanResourceManager.DataAccessLayers
{
    public class EmployeeDataAccessLayer : DataAccessLayer
    {
        // Возвращает всю информацию о всех сотрудниках
        public List<Employee> GetAllEmployees()
        {
            List<SqlParameter> storedProcedureParameters = new List<SqlParameter> { };

            StoredProcedure storedProcedure = new StoredProcedure("spGetAllEmployees", storedProcedureParameters);

            DataSet resultDataSet = storedProcedure.Execute();

            List<Employee> employees = new List<Employee>();

            if (resultDataSet != null)
            {
                employees = DataTableConverter.CreateListFromTable<Employee>(resultDataSet.Tables[0]);
            }

            return employees;

            //using (SqlConnection connection = new SqlConnection(ConnectionString))
            //{
            //    SqlCommand command = new SqlCommand("spGetAllEmployees", connection);
            //    command.CommandType = CommandType.StoredProcedure;

            //    connection.Open();
            //    SqlDataReader reader = command.ExecuteReader();

            //    while (reader.Read())
            //    {
            //        Employee employee = new Employee(

            //            Convert.ToInt32(reader["Id"]),

            //            new Position(
            //                Convert.ToInt32(reader["PositionId"]),
            //                reader["PositionName"].ToString()
            //                ),

            //            new Company(
            //                Convert.ToInt32(reader["CompanyId"]),

            //                new OrganizationalType(
            //                    Convert.ToInt32(reader["OrganizationalTypeId"]),
            //                    reader["OrganizationalTypeName"].ToString()
            //                    ),

            //                new ActivityType(
            //                    Convert.ToInt32(reader["ActivitiTypeId"]),
            //                    reader["ActivityTypeName"].ToString()
            //                    ),
            //                reader["CompanyName"].ToString(),
            //                Convert.ToInt32(reader["Size"])
            //                ),
            //            reader["Name"].ToString(),
            //            reader["Surname"].ToString(),
            //            reader["MiddleName"].ToString(),
            //            Convert.ToDateTime(reader["DateOfEmployment"])

            //            );

            //        employees.Add(employee);
            //    }
            //    connection.Close();
            //}

            //return employees;
        }

        // Добавляет нового сотрудника   
        public void AddEmployee(Employee employee)
        {
            List<SqlParameter> storedProcedureParameters = new List<SqlParameter>
            {
                new SqlParameter("@PositionId", employee.Position.Id),
                new SqlParameter("@CompanyId", employee.Company.Id),
                new SqlParameter("@Surname", employee.Surname),
                new SqlParameter("@MiddleName", employee.MiddleName),
                new SqlParameter("@DateOfEmployment", employee.DateOfEmployment),
                new SqlParameter("@Name", employee.Name)
            };

            StoredProcedure storedProcedure = new StoredProcedure("spAddEmployee", storedProcedureParameters);

            try
            {
                storedProcedure.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }


            //using (SqlConnection connection = new SqlConnection(ConnectionString))
            //{
            //    SqlCommand command = new SqlCommand("spAddEmployee", connection);
            //    command.CommandType = CommandType.StoredProcedure;

            //    command.Parameters.AddWithValue("@PositionId", employee.Position.Id);
            //    command.Parameters.AddWithValue("@CompanyId", employee.Company.Id);
            //    command.Parameters.AddWithValue("@Name", employee.Name);
            //    command.Parameters.AddWithValue("@Surname", employee.Surname);
            //    command.Parameters.AddWithValue("@MiddleName", employee.MiddleName);
            //    command.Parameters.AddWithValue("@DateOfEmployment", employee.DateOfEmployment);

            //    connection.Open();
            //    try
            //    {
            //        command.ExecuteNonQuery();
            //    }
            //    catch (SqlException)
            //    {
            //    }
            //    connection.Close();
            //}
        }

        // Обновляет данные о сотруднике  
        public void UpdateEmployee(Employee employee)
        {
            List<SqlParameter> storedProcedureParameters = new List<SqlParameter>
            {
                new SqlParameter("@Id", employee.Id),
                new SqlParameter("@PositionId", employee.Position.Id),
                new SqlParameter("@CompanyId", employee.Company.Id),
                new SqlParameter("@Surname", employee.Surname),
                new SqlParameter("@MiddleName", employee.MiddleName),
                new SqlParameter("@DateOfEmployment", employee.DateOfEmployment),
                new SqlParameter("@Name", employee.Name)
            };

            StoredProcedure storedProcedure = new StoredProcedure("spUpdateEmployee", storedProcedureParameters);

            try
            {
                storedProcedure.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }

            //using (SqlConnection connection = new SqlConnection(ConnectionString))
            //{
            //    SqlCommand command = new SqlCommand("spUpdateEmployee", connection);
            //    command.CommandType = CommandType.StoredProcedure;

            //    command.Parameters.AddWithValue("@Id", employee.Id);
            //    command.Parameters.AddWithValue("@PositionId", employee.Position.Id);
            //    command.Parameters.AddWithValue("@CompanyId", employee.Company.Id);
            //    command.Parameters.AddWithValue("@Name", employee.Name);
            //    command.Parameters.AddWithValue("@Surname", employee.Surname);
            //    command.Parameters.AddWithValue("@MiddleName", employee.MiddleName);
            //    command.Parameters.AddWithValue("@DateOfEmployment", employee.DateOfEmployment);

            //    connection.Open();
            //    try
            //    {
            //        command.ExecuteNonQuery();
            //    }
            //    catch (SqlException)
            //    {
            //    }
            //    connection.Close();
            //}
        }

        // Удаляет запись о сотруднике  
        public void DeleteEmployee(int id)
        {
            Delete(id, "spDeleteEmployee");
        }

        // Возвращает сотрудника по ID  
        public Employee GetEmployeeData(int id)
        {
            List<SqlParameter> storedProcedureParameters = new List<SqlParameter>
            {
                new SqlParameter("@Id", id)
            };

            StoredProcedure storedProcedure = new StoredProcedure("spGetEmployee", storedProcedureParameters);

            DataSet resultDataSet = storedProcedure.Execute();

            Employee employee = null;

            if (resultDataSet != null)
            {
                employee = DataTableConverter.CreateObjectFromTable<Employee>(resultDataSet.Tables[0]);
            }

            return employee;

            //using (SqlConnection connection = new SqlConnection(ConnectionString))
            //{
            //    SqlCommand command = new SqlCommand("spGetEmployee", connection);
            //    command.CommandType = CommandType.StoredProcedure;

            //    command.Parameters.AddWithValue("@Id", id);

            //    connection.Open();
            //    SqlDataReader reader = command.ExecuteReader();

            //    while (reader.Read())
            //    {
            //        employee = new Employee(
            //            Convert.ToInt32(reader["Id"]),

            //            new Position(
            //                Convert.ToInt32(reader["PositionId"]),
            //                reader["PositionName"].ToString()
            //                ),

            //            new Company(
            //                Convert.ToInt32(reader["CompanyId"]),

            //                new OrganizationalType(
            //                    Convert.ToInt32(reader["OrganizationalTypeId"]),
            //                    reader["OrganizationalTypeName"].ToString()
            //                    ),

            //                new ActivityType(
            //                    Convert.ToInt32(reader["ActivitiTypeId"]),
            //                    reader["ActivityTypeName"].ToString()
            //                    ),
            //                reader["CompanyName"].ToString(),
            //                Convert.ToInt32(reader["Size"])
            //                ),
            //            reader["Name"].ToString(),
            //            reader["Surname"].ToString(),
            //            reader["MiddleName"].ToString(),
            //            Convert.ToDateTime(reader["DateOfEmployment"])
            //            );
            //    }
            //    connection.Close();
            //}

            //return employee;
        }

        //Проверяет, существует ли тип сотрудник с таким id
        public bool IsEmployeeExist(int id)
        {
            return IsExist(id, "spIsEmployeeExist");
        }
    }
}

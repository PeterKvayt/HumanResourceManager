using HumanResourceManager.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace HumanResourceManager.DataAccessLayers
{
    public class CompanyDataAccessLayer : DataAccessLayer
    {
        // Возвращает всю информацию о всех компаниях
        public List<Company> GetAllCompanies()
        {
            List<Company> companies = new List<Company>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand("spGetAllCompanies", connection);
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Company company = new Company(

                        Convert.ToInt32(reader["Id"]),

                        new OrganizationalType(
                            Convert.ToInt32(reader["OrganizationalTypeId"]),
                            reader["OrganizationalTypeName"].ToString()
                            ),

                        new ActivityType(
                            Convert.ToInt32(reader["ActivityTypeId"]),
                            reader["ActivityTypeName"].ToString()
                            ),
                        reader["Name"].ToString(),
                        Convert.ToInt32(reader["Size"])

                        );

                    companies.Add(company);
                }
                connection.Close();
            }

            return companies;
        }

        // Добавляет компанию   
        public void AddCompany(Company company)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand("spAddCompany", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@ActivityTypeId", company.ActivityType.Id);
                command.Parameters.AddWithValue("@OrganizationalTypeId", company.OrganizationalType.Id);
                command.Parameters.AddWithValue("@Name", company.Name);

                connection.Open();
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (SqlException)
                {
                }
                connection.Close();
            }
        }

        // Обновляет данные о компании  
        public void UpdateCompany(Company company)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand("spUpdateCompany", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Id", company.Id);
                command.Parameters.AddWithValue("@ActivityTypeId", company.ActivityType.Id);
                command.Parameters.AddWithValue("@OrganizationalTypeId", company.OrganizationalType.Id);
                command.Parameters.AddWithValue("@Name", company.Name);

                connection.Open();
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (SqlException)
                {
                }
                connection.Close();
            }
        }

        // Удаляет компанию из бд  
        public void DeleteEmployee(int id)
        {
            Delete(id, "spDeleteCompany");
        }

        // Возвращает сотрудника по ID  
        public Company GetCompanyData(int id)
        {
            Company company = new Company();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand("spGetCompany", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Id", id);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    company = new Company(
                        Convert.ToInt32(reader["Id"]),

                        new OrganizationalType(
                                Convert.ToInt32(reader["OrganizationalTypeId"]),
                                reader["OrganizationalTypeName"].ToString()
                                ),

                        new ActivityType(
                                Convert.ToInt32(reader["ActivitiTypeId"]),
                                reader["ActivityTypeName"].ToString()
                                ),

                        reader["Name"].ToString(),
                        Convert.ToInt32(reader[6])

                        );
                }
                connection.Close();
            }

            return company;
        }

        //Проверяет, существует ли компания с таким id
        public bool IsCompanyExist(int id)
        {
            return IsExist(id, "spIsCompanyExist");
        }
    }
}

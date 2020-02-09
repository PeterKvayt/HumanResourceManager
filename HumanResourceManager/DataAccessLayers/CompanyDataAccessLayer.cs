using HumanResourceManager.DataBaseEntranceLayer;
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

            List<SqlParameter> storedProcedureParameters = new List<SqlParameter> { };

            StoredProcedure storedProcedure = new StoredProcedure("spGetAllCompanies", storedProcedureParameters);

            SqlDataReader reader = m_QueriesExecutor.ExecuteReaderStoredProcedure(storedProcedure);
            try
            {
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
            }
            catch (Exception)
            {

                throw;
            }

            return companies;


            //using (SqlConnection connection = new SqlConnection(ConnectionString))
            //{
            //    SqlCommand command = new SqlCommand("spGetAllCompanies", connection);
            //    command.CommandType = CommandType.StoredProcedure;

            //    connection.Open();
            //    SqlDataReader reader = command.ExecuteReader();

            //    while (reader.Read())
            //    {
            //        Company company = new Company(

            //            Convert.ToInt32(reader["Id"]),

            //            new OrganizationalType(
            //                Convert.ToInt32(reader["OrganizationalTypeId"]),
            //                reader["OrganizationalTypeName"].ToString()
            //                ),

            //            new ActivityType(
            //                Convert.ToInt32(reader["ActivityTypeId"]),
            //                reader["ActivityTypeName"].ToString()
            //                ),
            //            reader["Name"].ToString(),
            //            Convert.ToInt32(reader["Size"])

            //            );

            //        companies.Add(company);
            //    }
            //    connection.Close();
            //}

        }

        // Добавляет компанию   
        public void AddCompany(Company company)
        {
            List<SqlParameter> storedProcedureParameters = new List<SqlParameter>
            {
                new SqlParameter("@ActivityTypeId", company.ActivityType.Id),
                new SqlParameter("@OrganizationalTypeId", company.OrganizationalType.Id),
                new SqlParameter("@Name", company.Name)
            };

            StoredProcedure storedProcedure = new StoredProcedure("spAddCompany", storedProcedureParameters);

            try
            {
                m_QueriesExecutor.ExecuteNonQueryStoredProcedure(storedProcedure);
            }
            catch (Exception)
            {

                throw;
            }


            //using (SqlConnection connection = new SqlConnection(ConnectionString))
            //{
            //    SqlCommand command = new SqlCommand("spAddCompany", connection);
            //    command.CommandType = CommandType.StoredProcedure;

            //    command.Parameters.AddWithValue("@ActivityTypeId", company.ActivityType.Id);
            //    command.Parameters.AddWithValue("@OrganizationalTypeId", company.OrganizationalType.Id);
            //    command.Parameters.AddWithValue("@Name", company.Name);

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

        // Обновляет данные о компании  
        public void UpdateCompany(Company company)
        {
            List<SqlParameter> storedProcedureParameters = new List<SqlParameter>
            {
                new SqlParameter("@Id", company.Id),
                new SqlParameter("@ActivityTypeId", company.ActivityType.Id),
                new SqlParameter("@OrganizationalTypeId", company.OrganizationalType.Id),
                new SqlParameter("@Name", company.Name)
            };

            StoredProcedure storedProcedure = new StoredProcedure("spUpdateCompany", storedProcedureParameters);

            try
            {
                m_QueriesExecutor.ExecuteNonQueryStoredProcedure(storedProcedure);
            }
            catch (Exception)
            {

                throw;
            }


            //using (SqlConnection connection = new SqlConnection(ConnectionString))
            //{
            //    SqlCommand command = new SqlCommand("spUpdateCompany", connection);
            //    command.CommandType = CommandType.StoredProcedure;

            //    command.Parameters.AddWithValue("@Id", company.Id);
            //    command.Parameters.AddWithValue("@ActivityTypeId", company.ActivityType.Id);
            //    command.Parameters.AddWithValue("@OrganizationalTypeId", company.OrganizationalType.Id);
            //    command.Parameters.AddWithValue("@Name", company.Name);

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

        // Удаляет компанию из бд  
        public void DeleteEmployee(int id)
        {
            Delete(id, "spDeleteCompany");
        }

        // Возвращает сотрудника по ID  
        public Company GetCompanyData(int id)
        {
            List<SqlParameter> storedProcedureParameters = new List<SqlParameter>
            {
                new SqlParameter("@Id", id)
            };

            StoredProcedure storedProcedure = new StoredProcedure("spGetCompany", storedProcedureParameters);

            SqlDataReader reader = m_QueriesExecutor.ExecuteReaderStoredProcedure(storedProcedure);

            Company company = new Company();

            try
            {
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

                return company;
            }
            catch (Exception)
            {

                throw;
            }



            //Company company = new Company();

            //using (SqlConnection connection = new SqlConnection(ConnectionString))
            //{
            //    SqlCommand command = new SqlCommand("spGetCompany", connection);
            //    command.CommandType = CommandType.StoredProcedure;

            //    command.Parameters.AddWithValue("@Id", id);

            //    connection.Open();
            //    SqlDataReader reader = command.ExecuteReader();

            //    while (reader.Read())
            //    {
            //        company = new Company(
            //            Convert.ToInt32(reader["Id"]),

            //            new OrganizationalType(
            //                    Convert.ToInt32(reader["OrganizationalTypeId"]),
            //                    reader["OrganizationalTypeName"].ToString()
            //                    ),

            //            new ActivityType(
            //                    Convert.ToInt32(reader["ActivitiTypeId"]),
            //                    reader["ActivityTypeName"].ToString()
            //                    ),

            //            reader["Name"].ToString(),
            //            Convert.ToInt32(reader[6])

            //            );
            //    }
            //    connection.Close();
            //}

            //return company;
        }

        //Проверяет, существует ли компания с таким id
        public bool IsCompanyExist(int id)
        {
            return IsExist(id, "spIsCompanyExist");
        }
    }
}

using HumanResourceManager.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace HumanResourceManager.DataAccessLayers
{
    public class DataAccessLayer
    {
        //Получение строки подключения к бд
        protected string ConnectionString { get; } = Startup.ConnectionString;

        //Возвращает конкретный экземпляр из бд
        protected CommonStructure GetParticularData(int id, string storedProcedure)
        {
            CommonStructure entity = new CommonStructure();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(storedProcedure, connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Id", id);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    entity = new CommonStructure(

                        Convert.ToInt32(reader["Id"]),
                        reader["Name"].ToString()

                        );
                }
                connection.Close();
            }

            return entity;
        }

        //Преобразует к ActivityType
        protected ActivityType ToActivityType(CommonStructure structure)
        {
            return new ActivityType(structure.Id, structure.Name);
        }

        //Перегруженная версия для преобразования списка
        protected List<ActivityType> ToActivityType(List<CommonStructure> structures)
        {
            List<ActivityType> list = new List<ActivityType>();

            foreach (var item in structures)
            {
                list.Add(ToActivityType(item));
            }

            return list;
        }

        //Преобразует к OrganizationalType
        protected OrganizationalType ToOrganizationalType(CommonStructure structure)
        {
            return new OrganizationalType(structure.Id, structure.Name);
        }

        //Перегруженная версия для преобразования списка
        protected List<OrganizationalType> ToOrganizationalType(List<CommonStructure> structures)
        {
            List<OrganizationalType> list = new List<OrganizationalType>();

            foreach (var item in structures)
            {
                list.Add(ToOrganizationalType(item));
            }

            return list;
        }

        //Преобразует к Position
        protected Position ToPosition(CommonStructure structure)
        {
            return new Position(structure.Id, structure.Name);
        }

        //Перегруженная версия для преобразования списка
        protected List<Position> ToPosition(List<CommonStructure> structures)
        {
            List<Position> list = new List<Position>();

            foreach (var item in structures)
            {
                list.Add(ToPosition(item));
            }

            return list;
        }

        //Удаляет запись из бд экземпляра класса, наследованного от CommonStructure
        protected void Delete(int id, string storedProcedure)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(storedProcedure, connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Id", id);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        //Добавляет запись в бд экземпляра класса, наследованного от CommonStructure
        protected void Add(string value, string storedProcedure)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(storedProcedure, connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Name", value);

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

        //Обновляет запись в бд экземпляра класса, наследованного от CommonStructure
        protected void Update(CommonStructure entity, string storedProcedure)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(storedProcedure, connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Id", entity.Id);
                command.Parameters.AddWithValue("@Name", entity.Name);

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

        //Возвращает все записи экземпляра класса, наследованного от CommonStructure
        protected List<CommonStructure> GetAll(string storedProcedure)
        {
            List<CommonStructure> commonStructureList = new List<CommonStructure>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(storedProcedure, connection);
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    CommonStructure entity = new CommonStructure(

                        Convert.ToInt32(reader["Id"]),
                        reader["Name"].ToString()

                        );

                    commonStructureList.Add(entity);
                }
                connection.Close();
            }

            return commonStructureList;
        }

        //Проверяет, есть ли такой объект в бд
        protected bool IsExist(int id, string storedProcedure)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(storedProcedure, connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@id", id);

                SqlParameter isExist = new SqlParameter
                {
                    ParameterName = "@exist",
                    SqlDbType = SqlDbType.Int
                };
                isExist.Direction = ParameterDirection.Output;

                command.Parameters.Add(isExist);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                return Convert.ToInt32(command.Parameters["@exist"].Value) == 1 ? true : false;
            }
        }
    }
}

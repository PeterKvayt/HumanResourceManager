using HumanResourceManager.DataBaseEntranceLayer;
using HumanResourceManager.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace HumanResourceManager.DataAccessLayers
{
    public class DataAccessLayer
    {
        /// <summary>
        /// Инициализирует объект, который будет выполнять запросы к базе данных
        /// </summary>
        protected DataBaseQueriesExecutor m_QueriesExecutor { get; } = new DataBaseQueriesExecutor();

        //Возвращает конкретный экземпляр из базы данных
        protected CommonStructure GetParticularData(int inputId, string inputStoredProcedureName)
        {
            List<SqlParameter> storedProcedureParameters = new List<SqlParameter>
            {
                new SqlParameter("@Id", inputId)
            };

            StoredProcedure storedProcedure = new StoredProcedure(inputStoredProcedureName, storedProcedureParameters);

            SqlDataReader reader = m_QueriesExecutor.ExecuteReaderStoredProcedure(storedProcedure);

            CommonStructure commonStructure = null;

            try
            {
                while (reader.Read())
                {
                    commonStructure = new CommonStructure(

                        Convert.ToInt32(reader["Id"]),
                        reader["Name"].ToString()

                        );
                }
            }
            catch (Exception)
            {
                throw;
            }

            return commonStructure;

            //foreach (DataRow row in dataTable.Rows)
            //{
            //    var cell = row.ItemArray;

            //    commonStructure = new CommonStructure((int)cell[0], cell[1].ToString());
            //}



            //CommonStructure entity = new CommonStructure();

            //using (SqlConnection connection = new SqlConnection(ConnectionString))
            //{
            //    SqlCommand command = new SqlCommand(storedProcedure, connection);
            //    command.CommandType = CommandType.StoredProcedure;

            //    command.Parameters.AddWithValue("@Id", id);

            //    connection.Open();
            //    SqlDataReader reader = command.ExecuteReader();

            //    while (reader.Read())
            //    {
            //        entity = new CommonStructure(

            //            Convert.ToInt32(reader["Id"]),
            //            reader["Name"].ToString()

            //            );
            //    }
            //    connection.Close();
            //}

            //return entity;
        }

        #region Convert

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

        #endregion

        //Удаляет запись из базы данных экземпляра класса, наследованного от CommonStructure
        protected void Delete(int inputId, string inputStoredProcedureName)
        {
            List<SqlParameter> storedProcedureParameters = new List<SqlParameter>
            {
                new SqlParameter("@Id", inputId)
            };

            StoredProcedure storedProcedure = new StoredProcedure(inputStoredProcedureName, storedProcedureParameters);

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
            //    SqlCommand command = new SqlCommand(storedProcedure, connection);
            //    command.CommandType = CommandType.StoredProcedure;

            //    command.Parameters.AddWithValue("@Id", id);

            //    connection.Open();
            //    command.ExecuteNonQuery();
            //    connection.Close();
            //}
        }

        //Добавляет запись в базу данных экземпляра класса, наследованного от CommonStructure
        protected void Add(string inputName, string inputStoredProcedureName)
        {
            List<SqlParameter> storedProcedureParameters = new List<SqlParameter>
            {
                new SqlParameter("@Name", inputName)
            };

            StoredProcedure storedProcedure = new StoredProcedure(inputStoredProcedureName, storedProcedureParameters);

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
            //    SqlCommand command = new SqlCommand(storedProcedure, connection);
            //    command.CommandType = CommandType.StoredProcedure;

            //    command.Parameters.AddWithValue("@Name", value);

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

        //Обновляет запись в базы данных экземпляра класса, наследованного от CommonStructure
        protected void Update(CommonStructure entity, string inputStoredProcedureName)
        {
            List<SqlParameter> storedProcedureParameters = new List<SqlParameter>
            {
                new SqlParameter("@Id", entity.Id),
                new SqlParameter("@Name", entity.Name)
            };

            StoredProcedure storedProcedure = new StoredProcedure(inputStoredProcedureName, storedProcedureParameters);

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
            //    SqlCommand command = new SqlCommand(storedProcedure, connection);
            //    command.CommandType = CommandType.StoredProcedure;

            //    command.Parameters.AddWithValue("@Id", entity.Id);
            //    command.Parameters.AddWithValue("@Name", entity.Name);

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

        //Возвращает все записи экземпляра класса, наследованного от CommonStructure
        protected List<CommonStructure> GetAll(string inputStoredProcedureName)
        {
            List<CommonStructure> commonStructureList = new List<CommonStructure>();

            List<SqlParameter> storedProcedureParameters = new List<SqlParameter> { };

            StoredProcedure storedProcedure = new StoredProcedure(inputStoredProcedureName, storedProcedureParameters);

            SqlDataReader reader = m_QueriesExecutor.ExecuteReaderStoredProcedure(storedProcedure);

            try
            {
                while (reader.Read())
                {
                    CommonStructure entity = new CommonStructure(

                        Convert.ToInt32(reader["Id"]),
                        reader["Name"].ToString()

                        );

                    commonStructureList.Add(entity);
                }
            }
            catch (Exception)
            {

                throw;
            }

            return commonStructureList;



            //foreach (DataRow row in dataTable.Rows)
            //{
            //    var cell = row.ItemArray;

            //    commonStructure = new CommonStructure((int)cell[0], cell[1].ToString());

            //    commonStructureList.Add(commonStructure);
            //}


            //using (SqlConnection connection = new SqlConnection(ConnectionString))
            //{
            //    SqlCommand command = new SqlCommand(storedProcedure, connection);
            //    command.CommandType = CommandType.StoredProcedure;

            //    connection.Open();
            //    SqlDataReader reader = command.ExecuteReader();

            //    while (reader.Read())
            //    {
            //        CommonStructure entity = new CommonStructure(

            //            Convert.ToInt32(reader["Id"]),
            //            reader["Name"].ToString()

            //            );

            //        commonStructureList.Add(entity);
            //    }
            //    connection.Close();
            //}

            //return commonStructureList;
        }

        //Проверяет, есть ли такой объект в бд
        protected bool IsExist(int inputId, string inputStoredProcedureName)
        {
            List<SqlParameter> storedProcedureParameters = new List<SqlParameter>
            {
                new SqlParameter("@Id", inputId),
                new SqlParameter
                {
                    ParameterName = "@exist",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                }
            };

            StoredProcedure storedProcedure = new StoredProcedure(inputStoredProcedureName, storedProcedureParameters);

            m_QueriesExecutor.ExecuteNonQueryStoredProcedure(storedProcedure);

            try
            {
                bool isExist = Convert.ToInt32(storedProcedureParameters[1].Value) == 1 ? true : false;

                return isExist;
            }
            catch (Exception)
            {

                throw;
            }




            //using (SqlConnection connection = new SqlConnection(ConnectionString))
            //{
            //    SqlCommand command = new SqlCommand(storedProcedure, connection);
            //    command.CommandType = CommandType.StoredProcedure;

            //    command.Parameters.AddWithValue("@id", id);

            //    SqlParameter isExist = new SqlParameter
            //    {
            //        ParameterName = "@exist",
            //        SqlDbType = SqlDbType.Int
            //    };
            //    isExist.Direction = ParameterDirection.Output;

            //    command.Parameters.Add(isExist);

            //    connection.Open();
            //    command.ExecuteNonQuery();
            //    connection.Close();

            //    return Convert.ToInt32(command.Parameters["@exist"].Value) == 1 ? true : false;
        
        }
    }
}

using System;
using System.Data;
using System.Data.SqlClient;

namespace HumanResourceManager.DataBaseEntranceLayer
{
    /// <summary>
    /// Выполняет запросы к базе данных
    /// </summary>
    public class DataBaseQueriesExecutor
    {
        private readonly DataBaseConnection m_DataBaseConnection = new DataBaseConnection();

        /// <summary>
        /// Выполняет хранимую процедуру
        /// </summary>
        /// <param name="inputStoredProcedure"></param>
        /// <returns>Возвращает SqlDataReader</returns>
        public SqlDataReader ExecuteReaderStoredProcedure(StoredProcedure inputStoredProcedure)
        {
            using (SqlConnection sqlDataBaseConnection = m_DataBaseConnection.Connection)
            {
                sqlDataBaseConnection.Open();

                SqlCommand storedProcedureCommand = GetStoredProcedureCommand(inputStoredProcedure);

                try
                {
                    SqlDataReader reader = storedProcedureCommand.ExecuteReader();

                    return reader;
                }
                catch (Exception)
                {
                    // ToDo: Обработать исключения выполнения запроса на заполнение dataset
                    throw;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputStoredProcedure"></param>
        public void ExecuteNonQueryStoredProcedure(StoredProcedure inputStoredProcedure)
        {
            using (SqlConnection sqlDataBaseConnection = m_DataBaseConnection.GetDataBaseConnection())
            {
                SqlCommand storedProcedureCommand = GetStoredProcedureCommand(inputStoredProcedure);

                try
                {
                    storedProcedureCommand.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    // ToDo: Обработать исключения выполнения запроса на заполнение dataset
                    throw;
                }
            }
        }

        /// <summary>
        /// Получает хранимую процедуру и преобразует ее в sql-команду
        /// </summary>
        /// <param name="inputStoredProcedure">Хранимая процедура для преобразования в sql-команду</param>
        /// <returns>Возвращает sql-команду</returns>
        private SqlCommand GetStoredProcedureCommand(StoredProcedure inputStoredProcedure)
        {
            SqlCommand storedProcedureCommand = new SqlCommand
            {
                CommandText = inputStoredProcedure.Name,
                CommandType = StoredProcedure.GetCommandType(),
                Connection = m_DataBaseConnection.Connection
            };

            foreach (var sqlParameter in inputStoredProcedure.SqlParameters)
            {
                storedProcedureCommand.Parameters.Add(sqlParameter);
            }

            return storedProcedureCommand;
        }
    }
}

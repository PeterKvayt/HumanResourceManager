using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace HumanResourceManager.DataBaseEntranceLayer
{
    /// <summary>
    /// Выполняет запросы к базе данных
    /// </summary>
    public class DataBaseQueriesExecutor
    {
        private SqlConnection m_sqlConnection;

        /// <summary>
        /// Создание экземпляра подключения к базе данных. 
        /// </summary>
        public DataBaseQueriesExecutor()
        {
            if (!string.IsNullOrEmpty(Startup.DataBaseConnectionString) && !string.IsNullOrWhiteSpace(Startup.DataBaseConnectionString))
            {
                m_sqlConnection = new SqlConnection(Startup.DataBaseConnectionString);
            }
            else
            {
                // ToDo: Обработать отсутствие строки подключения к базе данных
            }
        }

        /// <summary>
        /// Открывает подключение к базе данных
        /// </summary>
        private void OpenDataBaseConnection()
        {
            if (m_sqlConnection.State == ConnectionState.Closed || m_sqlConnection.State == ConnectionState.Broken)
            {
                m_sqlConnection.Open();
            }
            else
            {
                // ToDo: Обработать ошибку открытия подключения к бд
            }
        }

        /// <summary>
        /// Выполняет хранимую процедуру
        /// </summary>
        /// <param name="inputStoredProcedure"></param>
        /// <returns>Возвращает результат выполнения хранимой процедуры в виде DataTable</returns>
        public DataTable ExecuteStoredProcedure(StoredProcedure inputStoredProcedure)
        {
            DataTable storedProcedureExecutingResult = null;

            using (SqlConnection sqlDataBaseConnection = m_sqlConnection)
            {
                OpenDataBaseConnection();

                SqlCommand storedProcedureCommand = GetStoredProcedureCommand(inputStoredProcedure);

                SqlDataAdapter dataAdapter = new SqlDataAdapter(storedProcedureCommand);

                DataSet dataSet = null;

                try
                {
                    dataAdapter.Fill(dataSet);
                }
                catch (Exception)
                {
                    // ToDo: Обработать исключения выполнения запроса на заполнение dataset
                }

                storedProcedureExecutingResult  = dataSet.Tables[0];
            }

            return storedProcedureExecutingResult ;
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
                CommandType = StoredProcedure.GetCommandType()
            };

            foreach (var sqlParameter in inputStoredProcedure.SqlParameters)
            {
                storedProcedureCommand.Parameters.Add(sqlParameter);
            }

            return storedProcedureCommand;
        }
    }
}

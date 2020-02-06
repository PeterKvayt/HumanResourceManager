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
        private readonly DataBaseConnection m_dataBaseConnection = new DataBaseConnection();

        /// <summary>
        /// Создание экземпляра подключения к базе данных. 
        /// </summary>
        public DataBaseQueriesExecutor() { }

        /// <summary>
        /// Выполняет хранимую процедуру
        /// </summary>
        /// <param name="inputStoredProcedure"></param>
        /// <returns>Возвращает результат выполнения хранимой процедуры в виде DataTable</returns>
        public DataTable ExecuteStoredProcedure(StoredProcedure inputStoredProcedure)
        {
            DataTable storedProcedureExecutingResult = null;

            using (SqlConnection sqlDataBaseConnection = m_dataBaseConnection.GetOpenedSqlConnection())
            {
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

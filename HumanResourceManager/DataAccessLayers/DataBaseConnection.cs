using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace HumanResourceManager.DataAccessLayers
{
    public class DataBaseConnection
    {
        private SqlConnection m_sqlConnection;

        /// <summary>
        /// Создание экземпляра подключения к базе данных. 
        /// </summary>
        public DataBaseConnection()
        {
            m_sqlConnection = new SqlConnection(Startup.DataBaseConnectionString);
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
        }

        /// <summary>
        /// Выполняет хранимую процедуру
        /// </summary>
        /// <param name="storedProcedure"></param>
        /// <returns>Возвращает результат выполнения хранимой процедуры в виде DataTable</returns>
        public DataTable ExecuteStoredProcedure(StoredProcedure storedProcedure)
        {
            DataTable storedProcedureExecutingResult = null;

            using (SqlConnection sqlDataBaseConnection = m_sqlConnection)
            {
                OpenDataBaseConnection();

                SqlCommand storedProcedureCommand = GetSqlCommand(storedProcedure.Name, storedProcedure.SqlParameters, CommandType.StoredProcedure);

                SqlDataAdapter dataAdapter = new SqlDataAdapter(storedProcedureCommand);

                DataSet dataSet = null;

                try
                {
                    dataAdapter.Fill(dataSet);
                }
                catch (Exception)
                {
                    // ToDo: Обработать исключения выполнения 
                }

                storedProcedureExecutingResult  = dataSet.Tables[0];
            }

            return storedProcedureExecutingResult ;
        }

        /// <summary>
        /// Возвращает sql команду
        /// </summary>
        /// <param name="sqlCommandExpression">sql выражение для команды</param>
        /// <param name="sqlCommandType">Тип sql команды</param>
        /// <param name="sqlCommandParameters">Параметры sql команды</param>
        /// <returns></returns>
        private SqlCommand GetSqlCommand(string sqlCommandExpression, List<SqlParameter> sqlCommandParameters, CommandType sqlCommandType)
        {
            if (!string.IsNullOrEmpty(sqlCommandExpression) && !string.IsNullOrWhiteSpace(sqlCommandExpression))
            {
                SqlCommand sqlCommand = new SqlCommand(sqlCommandExpression)
                {
                    CommandType = sqlCommandType
                };

                if (sqlCommandParameters.Count >= 1)
                {
                    foreach (var sqlParameter in sqlCommandParameters)
                    {
                        sqlCommand.Parameters.Add(sqlParameter);
                    }

                    return sqlCommand;
                }
                else
                {
                    return null;
                    // ToDo: Обработать отсутствие параметров для создания sql-команды
                }
            }
            else
            {
                return null;
                // ToDo: Обработать отсутствие sql-выражения для создания sql-команды
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace HumanResourceManager.DataBaseEntranceLayer
{
    public class StoredProcedure
    {
        /// <summary>
        /// Возвращает название хранимой процедуры
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Возвращает список параметров хранимой процедуры
        /// </summary>
        public List<SqlParameter> SqlParameters { get; }

        /// <summary>
        /// Создает экземпляр класса StoredProcedure
        /// </summary>
        /// <param name="storedProcedureName">Имя хранимой процедуры</param>
        /// <param name="sqlParameters">Параметры хранимой процедуры</param>
        public StoredProcedure(string storedProcedureName, List<SqlParameter> sqlParameters)
        {
            if ( !(string.IsNullOrEmpty(storedProcedureName) && string.IsNullOrWhiteSpace(storedProcedureName)) )
            {
                if (sqlParameters.Count >= GetSqlParametersCountMin())
                {
                    Name = storedProcedureName;
                    SqlParameters = sqlParameters;
                }
                else
                {
                    // ToDo: обработать неподходящее количество параметров хранимой процедуры
                }
            }
            else
            {
                // ToDo: обработать отсутствие названия процедуры
            }
        }

        /// <summary>
        /// Минимальное количество sql параметров для хранимой процедуры
        /// </summary>
        private const int m_SQL_PARAMETERS_COUNT_MIN = 0;

        /// <summary>
        /// Возвращает минимальное количество sql параметров для хранимой процедуры
        /// </summary>
        public static int GetSqlParametersCountMin()
        {
            return m_SQL_PARAMETERS_COUNT_MIN;
        }

        /// <summary>
        /// Константа тип команды для создания sql-команд
        /// </summary>
        private const CommandType m_COMMAND_TYPE = CommandType.StoredProcedure;

        /// <summary>
        /// Возвращает константу тип команды для создания sql-команд
        /// </summary>
        public static CommandType GetCommandType()
        {
            return m_COMMAND_TYPE;
        }

        private readonly DataBaseConnection m_DataBaseConnection = new DataBaseConnection();

        /// <summary>
        /// Выполняет хранимую процедуру
        /// </summary>
        /// <param name="inputStoredProcedure"></param>
        /// <returns>Возвращает SqlDataReader</returns>
        public DataSet Execute()
        {
            using (SqlConnection sqlDataBaseConnection = m_DataBaseConnection.Connection)
            {
                sqlDataBaseConnection.Open();

                SqlCommand storedProcedureCommand = ToSqlCommand();

                SqlDataAdapter adapter = new SqlDataAdapter(storedProcedureCommand);

                DataSet dataSet = new DataSet();

                try
                {
                    adapter.Fill(dataSet);

                    return dataSet;
                }
                catch (Exception)
                {
                    // ToDo: Обработать исключения выполнения запроса на заполнение dataset
                    throw;
                }
            }
        }

        public void ExecuteNonQuery()
        {
            using (SqlConnection sqlDataBaseConnection = m_DataBaseConnection.Connection)
            {
                SqlCommand storedProcedureCommand = ToSqlCommand();

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
        private SqlCommand ToSqlCommand()
        {
            SqlCommand storedProcedureCommand = new SqlCommand
            {
                CommandText = Name,
                CommandType = GetCommandType(),
                Connection = m_DataBaseConnection.Connection
            };

            foreach (var sqlParameter in SqlParameters)
            {
                storedProcedureCommand.Parameters.Add(sqlParameter);
            }

            return storedProcedureCommand;
        }

    }
}

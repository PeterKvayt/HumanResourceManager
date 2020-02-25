using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer.DataAccess
{
    /// <summary>
    /// Класс отвечает за хранимые процедуры
    /// </summary>
    class StoredProcedure : IDataBaseExecutor
    {
        /// <summary>
        /// Название хранимой процедуры
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Список параметров хранимой процедуры
        /// </summary>
        public IEnumerable<SqlParameter> SqlParameters { get; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="storedProcedureName">Название хранимой процедуры</param>
        /// <param name="sqlParameters">Параметры хранимой процедуры</param>
        public StoredProcedure(string storedProcedureName, IEnumerable<SqlParameter> sqlParameters)
        {
            if (!(string.IsNullOrEmpty(storedProcedureName) && string.IsNullOrWhiteSpace(storedProcedureName)))
            {
                if (sqlParameters != null)
                {
                    Name = storedProcedureName;
                    SqlParameters = sqlParameters;
                }
                else
                {
                    // ToDo: обработать nullException
                }
            }
            else
            {
                // ToDo: обработать отсутствие названия процедуры
            }
        }

        /// <summary>
        /// Выполняет хранимую процедуру
        /// </summary>
        /// <returns>Возвращает данные из базы данных</returns>
        public DataSet Execute()
        {
            using (SqlConnection sqlDataBaseConnection = DataBaseConnection.GetConnection())
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

        /// <summary>
        /// Выполняет хранимую процедуру NonQuery
        /// </summary>
        public void ExecuteNonQuery()
        {
            using (SqlConnection sqlDataBaseConnection = DataBaseConnection.GetConnection())
            {
                sqlDataBaseConnection.Open();

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
                CommandType = CommandType.StoredProcedure,
                Connection = DataBaseConnection.GetConnection()
            };

            foreach (var sqlParameter in SqlParameters)
            {
                storedProcedureCommand.Parameters.Add(sqlParameter);
            }

            return storedProcedureCommand;
        }
    }
}

using DataAccessLayer.Interfaces;
using ExceptionClasses.Loggers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer.DataContext
{
    /// <summary>
    /// Класс отвечает за хранимые процедуры
    /// </summary>
    class StoredProcedure : IDataBaseCommandExecutor
    {
        /// <summary>
        /// Название хранимой процедуры
        /// </summary>
        private string _name;

        /// <summary>
        /// Список параметров хранимой процедуры
        /// </summary>
        private IEnumerable<SqlParameter> _sqlParameters;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="storedProcedureName">Название хранимой процедуры</param>
        /// <param name="sqlParameters">Параметры хранимой процедуры</param>
        public StoredProcedure(string storedProcedureName, IEnumerable<SqlParameter> sqlParameters)
        {
            if ( !(string.IsNullOrEmpty(storedProcedureName) && string.IsNullOrWhiteSpace(storedProcedureName)) )
            {
                if (sqlParameters != null)
                {
                    _name = storedProcedureName;
                    _sqlParameters = sqlParameters;
                }
                else
                {
                    const string EXCEPTION_MESSAGE = "Sql параметры = null!";

                    ExceptionLogger.LogError(EXCEPTION_MESSAGE);

                    throw new Exception();
                }
            }
            else
            {
                const string EXCEPTION_MESSAGE = "Некорректное (пустое) имя хранимой процедуры!";

                ExceptionLogger.LogError(EXCEPTION_MESSAGE);

                throw new Exception();
            }
        }

        /// <summary>
        /// Выполняет хранимую процедуру
        /// </summary>
        /// <returns>Возвращает данные из базы данных</returns>
        public DataSet Execute()
        {
            using (SqlConnection sqlDataBaseConnection = TryGetConnection())
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
                    const string EXCEPTION_MESSAGE = "Ошибка заполнения адаптера!";

                    ExceptionLogger.LogError(EXCEPTION_MESSAGE);

                    throw;
                }
            }
        }

        /// <summary>
        /// Выполняет хранимую процедуру NonQuery
        /// </summary>
        public void ExecuteNonQuery()
        {
            using (SqlConnection sqlDataBaseConnection = TryGetConnection())
            {
                sqlDataBaseConnection.Open();

                SqlCommand storedProcedureCommand = ToSqlCommand();

                try
                {
                    storedProcedureCommand.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    const string EXCEPTION_MESSAGE = "Ошибка выполнения хранимой процедуры ExecuteNonQuery!";

                    ExceptionLogger.LogError(EXCEPTION_MESSAGE);

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
                CommandText = _name,
                CommandType = CommandType.StoredProcedure,
                Connection = DataBaseConnection.GetConnection()
            };

            foreach (var sqlParameter in _sqlParameters)
            {
                storedProcedureCommand.Parameters.Add(sqlParameter);
            }

            return storedProcedureCommand;
        }

        /// <summary>
        /// Безопасно возвращает подключение к базе данных
        /// </summary>
        /// <returns>Подключение к базе данных</returns>
        private SqlConnection TryGetConnection()
        {
            try
            {
                return DataBaseConnection.GetConnection();
            }
            catch (Exception)
            {
                const string EXCEPTION_MESSAGE = "Отсутствует подключение к базе данных!";

                ExceptionLogger.LogError(EXCEPTION_MESSAGE);

                throw;
            }
        }
    }
}

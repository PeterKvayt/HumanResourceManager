using DataAccessLayer.DataAccess;
using DataAccessLayer.Interfaces;
using ExceptionClasses.Logers;
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
        /// Подключение к базе данных
        /// </summary>
        public SqlConnection Connection { get; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="storedProcedureName">Название хранимой процедуры</param>
        /// <param name="sqlParameters">Параметры хранимой процедуры</param>
        public StoredProcedure(string storedProcedureName, IEnumerable<SqlParameter> sqlParameters)
        {
            if ( !(string.IsNullOrEmpty(storedProcedureName) && string.IsNullOrWhiteSpace(storedProcedureName)) )
            {
                _name = storedProcedureName;
            }
            else
            {
                const string EXCEPTION_MESSAGE = "Пустое имя хранимой процедуры!";

                ExceptionLoger.Log(EXCEPTION_MESSAGE, typeof(StoredProcedure).Name, "StoredProcedure");

                throw new Exception();
            }

            if (sqlParameters != null)
            {
                _sqlParameters = sqlParameters;
            }
            else
            {
                const string EXCEPTION_MESSAGE = "Sql-параметры = null!";

                ExceptionLoger.Log(EXCEPTION_MESSAGE, typeof(StoredProcedure).Name, "StoredProcedure");

                throw new Exception();
            }

            try
            {
                Connection = DataBaseConnection.GetConnection();
            }
            catch (Exception exception)
            {
                ExceptionLoger.Log(exception);

                throw;
            }
        }

        /// <summary>
        /// Выполняет хранимую процедуру
        /// </summary>
        /// <returns>Возвращает reader с данными</returns>
        public SqlDataReader ExecuteReader()
        {
            SqlCommand storedProcedureCommand = GetSqlCommand();

            try
            {
                return storedProcedureCommand.ExecuteReader();
            }
            catch (Exception exception)
            {
                ExceptionLoger.Log(exception);

                throw;
            }
        }

        /// <summary>
        /// Выполняет хранимую процедуру NonQuery
        /// </summary>
        public void ExecuteNonQuery()
        {
            using (SqlConnection sqlDataBaseConnection = Connection)
            {
                sqlDataBaseConnection.Open();

                SqlCommand storedProcedureCommand = GetSqlCommand();

                try
                {
                    storedProcedureCommand.ExecuteNonQuery();
                }
                catch (Exception exception)
                {
                    ExceptionLoger.Log(exception);

                    throw;
                }
            }
        }

        /// <summary>
        /// Выполнение скалярного запроса
        /// </summary>
        /// <returns>Результат выполнения запроса</returns>
        public object ExecuteScalar()
        {
            using (SqlConnection sqlDataBaseConnection = Connection)
            {
                sqlDataBaseConnection.Open();

                SqlCommand storedProcedureCommand = GetSqlCommand();

                try
                {
                    return storedProcedureCommand.ExecuteScalar();
                }
                catch (Exception exception)
                {
                    ExceptionLoger.Log(exception);

                    throw;
                }
            }
        }

        /// <summary>
        /// Преобразует хранимую процедуру в sql-команду
        /// </summary>
        /// <returns>Возвращает sql-команду</returns>
        private SqlCommand GetSqlCommand()
        {
            SqlCommand storedProcedureCommand = new SqlCommand
            {
                CommandText = _name,
                CommandType = CommandType.StoredProcedure,
                Connection = Connection
            };

            foreach (var sqlParameter in _sqlParameters)
            {
                storedProcedureCommand.Parameters.Add(sqlParameter);
            }

            return storedProcedureCommand;
        }
    }
}

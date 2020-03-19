using ExceptionClasses.Loggers;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DataAccessLayer.DataAccess
{
    /// <summary>
    /// Отвечает за подключение к базе данных
    /// </summary>
    static class DataBaseConnection
    {
        /// <summary>
        /// Возвращает подключение к базе данных
        /// </summary>
        /// <returns>Подключение к базе данных</returns>
        public static SqlConnection GetConnection()
        {
            string connectionString = GetConnectionString();

            if ( !(string.IsNullOrEmpty(connectionString) && string.IsNullOrWhiteSpace(connectionString)) )
            {
                return new SqlConnection(connectionString);
            }
            else
            {
                string EXCEPTION_MESSAGE = "Отсутствует строка подключения";

                ExceptionLogger.Log(EXCEPTION_MESSAGE, typeof(DataBaseConnection).Name, "GetConnection");

                throw new Exception();
            }
        }

        /// <summary>
        /// Название файла со строками подключения к базе данных
        /// </summary>
        private const string CONNECTION_FILE_NAME = "connectionStrings.json";

        /// <summary>
        /// Достает строку подключения к базе данных из конфигурационного файла
        /// </summary>
        /// <returns>Строка подключения к базе данных</returns>
        private static string GetConnectionString()
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;

            IConfigurationRoot configurationRoot = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile(CONNECTION_FILE_NAME)
                .Build();

            string resultConnectionString = configurationRoot.GetConnectionString("DefaultConnection");

            return resultConnectionString;
        }
    }
}

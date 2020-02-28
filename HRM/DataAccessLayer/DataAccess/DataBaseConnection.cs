using System;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using ExceptionClasses.Handlers;
using ExceptionClasses.Interfaces;
using ExceptionClasses.Loggers;

namespace DataAccessLayer.DataContext
{
    /// <summary>
    /// Класс отвечает за подключение к базе данных
    /// </summary>
    internal static class DataBaseConnection
    {
        /// <summary>
        /// Создает подключение
        /// </summary>
        /// <returns>Возвращает подключение к базе данных</returns>
        public static SqlConnection GetConnection()
        {
            string connectionString = GetConnectionString();

            if ( !(string.IsNullOrEmpty(connectionString) && string.IsNullOrWhiteSpace(connectionString)) )
            {
                return new SqlConnection(connectionString);
            }
            else
            {
                const string EXCEPTION_MESSAGE = "Отсутствует строка подключения к базе данных!";

                ExceptionLogger.LogError(EXCEPTION_MESSAGE);

                throw new Exception();
            }
        }

        /// <summary>
        /// Создает строку подключения
        /// </summary>
        /// <returns>Возвращает строку подключения</returns>
        private static string GetConnectionString()
        {
            const string CONNECTION_NAME = "DefaultConnection";

            const string CONNECTION_SETTINGS_FILE_NAME = "connectionStrings.json";

            string filePath = AppDomain.CurrentDomain.BaseDirectory;

            IConfigurationRoot configurationRoot = new ConfigurationBuilder()
                .SetBasePath(filePath)
                .AddJsonFile(CONNECTION_SETTINGS_FILE_NAME)
                .Build();

            string resultConnectionString = configurationRoot.GetConnectionString(CONNECTION_NAME);

            return resultConnectionString;
        }
    }
}

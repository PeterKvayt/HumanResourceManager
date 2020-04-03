using ExceptionClasses.Logers;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;

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

                ExceptionLoger.Log(EXCEPTION_MESSAGE, typeof(DataBaseConnection).Name, "GetConnection");

                throw new Exception();
            }
        }

        /// <summary>
        /// Достает строку подключения к базе данных из конфигурационного файла
        /// </summary>
        /// <returns>Строка подключения к базе данных</returns>
        private static string GetConnectionString()
        {
            //string CONNECTION_FILE_NAME = "connectionStrings.json";
            string CONNECTION_FILE_NAME = "appsettings.json";

            string basePath = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug\\netcoreapp2.2", "");

            IConfigurationRoot configurationRoot = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile(CONNECTION_FILE_NAME)
                .Build();

            string resultConnectionString = configurationRoot.GetConnectionString("DefaultConnection");

            return resultConnectionString;
        }
    }
}

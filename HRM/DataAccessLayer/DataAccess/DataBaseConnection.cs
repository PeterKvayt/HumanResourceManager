using ExceptionClasses.Loggers;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DataAccessLayer.DataAccess
{
    static class DataBaseConnection
    {
        private static readonly string _connectionString = GetConnectionString();

        public static SqlConnection GetConnection()
        {
            if ( !(string.IsNullOrEmpty(_connectionString) && string.IsNullOrWhiteSpace(_connectionString)) )
            {
                return new SqlConnection(_connectionString);
            }
            else
            {
                string EXCEPTION_MESSAGE = "Отсутствует строка подключения";

                ExceptionLogger.Log(EXCEPTION_MESSAGE, typeof(DataBaseConnection).Name, "GetConnection");

                throw new Exception();
            }
        }

        private const string CONNECTION_FILE_NAME = "connectionStrings.json";

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

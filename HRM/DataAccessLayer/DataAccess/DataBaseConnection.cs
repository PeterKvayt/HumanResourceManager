using System;
//using System.Configuration;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace DataAccessLayer.DataAccess
{
    static class DataBaseConnection
    {
        /// <summary>
        /// Строка подключения.
        /// </summary>
        private static readonly string connectionString = GetConnectionString();

        public static SqlConnection GetConnection()
        {
            if ( !(string.IsNullOrEmpty(connectionString) && string.IsNullOrWhiteSpace(connectionString)) )
            {
                return new SqlConnection(connectionString);
            }
            else
            {
                // ToDo: exception
                throw new ArgumentNullException();
            }
        }

        private static string GetConnectionString()
        {
            const string CONNECTION_FILE_NAME = "connectionStrings.json";

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

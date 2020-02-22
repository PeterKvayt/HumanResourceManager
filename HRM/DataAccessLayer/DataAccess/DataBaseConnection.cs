using System;
using System.Configuration;
using System.Data.SqlClient;

namespace DataAccessLayer.DataAccess
{
    static class DataBaseConnection
    {
        /// <summary>
        /// Строка подключения
        /// </summary>
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["defaultConnectionString"].ConnectionString;

        public static SqlConnection GetConnection()
        {
            if (!(string.IsNullOrEmpty(connectionString) && string.IsNullOrWhiteSpace(connectionString)))
            {
                return new SqlConnection(connectionString);
            }
            else
            {
                // ToDo: exception
                throw new ArgumentNullException();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace HumanResourceManager.DataBaseEntranceLayer
{
    public class DataBaseConnection
    {
        /// <summary>
        /// Соединение с базой данных 
        /// </summary>
        private readonly SqlConnection m_sqlConnection;

        /// <summary>
        /// Открывает соединение с базой данных и возвращает его
        /// </summary>
        public SqlConnection GetOpenedSqlConnection()
        {
            OpenDataBaseConnection();

            return m_sqlConnection;
        }

        /// <summary>
        /// Создает экземпляр класса DataBaseConnection
        /// </summary>
        public DataBaseConnection()
        {
            string dataBaseСonnectionString = Startup.DataBaseConnectionString;

            if ( !(string.IsNullOrEmpty(dataBaseСonnectionString) && string.IsNullOrWhiteSpace(dataBaseСonnectionString)) )
            {
                m_sqlConnection = new SqlConnection(dataBaseСonnectionString);
            }
            else
            {
                // ToDo: Обработать отсутствие пути к базе данных
            }
        }

        /// <summary>
        /// Открывает подключение к базе данных
        /// </summary>
        private void OpenDataBaseConnection()
        {
            if (m_sqlConnection.State == ConnectionState.Closed || m_sqlConnection.State == ConnectionState.Broken)
            {
                m_sqlConnection.Open();
            }
            else
            {
                // ToDo: Обработать ошибку открытия подключения к бд
            }
        }
    }
}

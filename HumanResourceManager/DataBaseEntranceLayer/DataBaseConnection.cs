using System.Data;
using System.Data.SqlClient;

namespace HumanResourceManager.DataBaseEntranceLayer
{
    class DataBaseConnection
    {
        /// <summary>
        /// Соединение с базой данных 
        /// </summary>
        private readonly SqlConnection m_SqlConnection;

        /// <summary>
        /// Открывает соединение с базой данных и возвращает его
        /// </summary>
        public SqlConnection GetOpenedSqlConnection()
        {
            OpenDataBaseConnection();

            return m_SqlConnection;
        }

        /// <summary>
        /// Создает экземпляр класса DataBaseConnection
        /// </summary>
        public DataBaseConnection()
        {
            string dataBaseСonnectionString = Startup.DataBaseConnectionString;

            if ( !(string.IsNullOrEmpty(dataBaseСonnectionString) && string.IsNullOrWhiteSpace(dataBaseСonnectionString)) )
            {
                m_SqlConnection = new SqlConnection(dataBaseСonnectionString);
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
            if (m_SqlConnection.State == ConnectionState.Closed || m_SqlConnection.State == ConnectionState.Broken)
            {
                m_SqlConnection.Open();
            }
            else
            {
                // ToDo: Обработать ошибку открытия подключения к бд
            }
        }
    }
}

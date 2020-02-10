using System.Data;
using System.Data.SqlClient;

namespace HumanResourceManager.DataBaseEntranceLayer
{
    class DataBaseConnection
    {
        /// <summary>
        /// Возвращает соединение с базой данных
        /// </summary>
        public SqlConnection Connection { get; }

        /// <summary>
        /// Создает экземпляр класса DataBaseConnection
        /// </summary>
        public DataBaseConnection()
        {
            string dataBaseСonnectionString = Startup.DataBaseConnectionString;

            if ( !(string.IsNullOrEmpty(dataBaseСonnectionString) && string.IsNullOrWhiteSpace(dataBaseСonnectionString)) )
            {
                Connection = new SqlConnection(dataBaseСonnectionString);
            }
            else
            {
                // ToDo: Обработать отсутствие пути к базе данных
            }
        }

        /// <summary>
        /// Открывает подключение к базе данных
        /// </summary>
        //private void OpenDataBaseConnection()
        //{
        //    if (Connection.State == ConnectionState.Closed || Connection.State == ConnectionState.Broken)
        //    {
        //        Connection.Open();
        //    }
        //    else
        //    {
        //        // ToDo: Обработать ошибку открытия подключения к бд
        //    }
        //}
    }
}

using System.Data.SqlClient;

namespace DataAccessLayer.Interfaces
{
    interface IDataBaseCommandExecutor
    {
        /// <summary>
        /// Подключение к базе данных
        /// </summary>
        SqlConnection Connection { get; }

        /// <summary>
        /// Выполняет запрос к базе данных
        /// </summary>
        /// <returns>Возвращает результат запроса</returns>
        SqlDataReader ExecuteReader();

        /// <summary>
        /// Выполняет запрос NonQuery
        /// </summary>
        void ExecuteNonQuery();

        /// <summary>
        /// Выполняет скалярный запрос 
        /// </summary>
        /// <returns>Скалярное значение</returns>
        object ExecuteScalar();
    }
}

using System.Data;

namespace DataAccessLayer.Interfaces
{
    interface IDataBaseCommandExecutor
    {
        /// <summary>
        /// Выполняет запрос к базе данных
        /// </summary>
        /// <returns>Возвращает результат запроса</returns>
        DataSet Execute();

        /// <summary>
        /// Выполняет запрос NonQuery
        /// </summary>
        void ExecuteNonQuery();
    }
}

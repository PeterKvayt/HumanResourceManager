using System.Data;

namespace DataAccessLayer.Interfaces
{
    interface IDataBaseExecutor
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

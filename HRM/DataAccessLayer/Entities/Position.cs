using CommonClasses;

namespace DataAccessLayer.Entities
{
    /// <summary>
    /// Класс отвечает за сущность базы данных "Должность"
    /// </summary>
    public class Position
    {
        public IdType Id { get; set; }

        /// <summary>
        /// Название должности
        /// </summary>
        public string Name { get; set; }
    }
}
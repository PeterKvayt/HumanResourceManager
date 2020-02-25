using DataAccessLayer.AssistantClasses;

namespace DataAccessLayer.Entities
{
    /// <summary>
    /// Класс отвечает за сущность базы данных "Должность"
    /// </summary>
    internal class Position
    {
        public IdType Id { get; set; }

        /// <summary>
        /// Название должности
        /// </summary>
        public string Name { get; set; }
    }
}
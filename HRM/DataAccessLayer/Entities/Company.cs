using DataAccessLayer.AssistantClasses;

namespace DataAccessLayer.Entities
{
    /// <summary>
    /// Класс отвечает за сущность базы данных "Компания"
    /// </summary>
    public class Company
    {
        public IdType Id { get; set; }

        /// <summary>
        /// Название компании
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Идентификатор вида деятельности компании
        /// </summary>
        public IdType ActivityId { get; set; }

        /// <summary>
        /// Идентификатор организационно-правового вида деятельности компании
        /// </summary>
        public IdType LegalFormId { get; set; }
    }
}
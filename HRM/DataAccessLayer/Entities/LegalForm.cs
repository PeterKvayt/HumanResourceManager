using CommonClasses;

namespace DataAccessLayer.Entities
{
    /// <summary>
    /// Класс отвечает за сущность базы данных "Организационно-правовой вид деятельности"
    /// </summary>
    public class LegalForm
    {
        public IdType Id { get; set; }

        /// <summary>
        /// Название Организационно-правового вида деятельности
        /// </summary>
        public string Name { get; set; }
    }
}
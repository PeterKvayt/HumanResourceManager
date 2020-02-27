using CommonClasses;

namespace DataAccessLayer.Entities
{
    /// <summary>
    /// Класс отвечает за сущность базы данных "Вид деятельности"
    /// </summary>
    public class ActivityType
    {
        public IdType Id { get; set; }

        /// <summary>
        /// Название вида деятельности
        /// </summary>
        public string Name { get; set; }
    }
}
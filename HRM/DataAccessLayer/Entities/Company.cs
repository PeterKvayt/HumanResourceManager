using DataAccessLayer.AssistantClasses;

namespace DataAccessLayer.Entities
{
    public class Company
    {
        public IdType Id { get; set; }
        public string Name { get; set; }
        public IdType ActivityId { get; set; }
        public IdType FormId { get; set; }
    }
}
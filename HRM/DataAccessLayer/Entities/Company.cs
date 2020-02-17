using DataAccessLayer.Classes;

namespace DataAccessLayer.Entities
{
    public class Company
    {
        public IdType Id { get; set; }
        public string Name { get; set; }
        public ActivityType Activity { get; set; }
        public LegalForm Form { get; set; }
    }
}
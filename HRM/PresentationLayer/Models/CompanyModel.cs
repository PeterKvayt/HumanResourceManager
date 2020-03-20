using CommonClasses;

namespace PresentationLayer.Models
{
    public class CompanyModel
    {
        public IdType Id { get; set; }

        public string Name { get; set; }

        public ActivityTypeModel ActivityType { get; set; }

        public LegalFormModel LegalForm { get; set; }

        public int Size { get; set; }
    }
}

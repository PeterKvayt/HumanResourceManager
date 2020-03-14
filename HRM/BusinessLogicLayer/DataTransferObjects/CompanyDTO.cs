using BusinessLogicLayer.Interfaces;
using CommonClasses;

namespace BusinessLogicLayer.DataTransferObjects
{
    public class CompanyDTO : IDataTransferObject
    {
        public IdType Id { get; set; }

        public string Name { get; set; }

        public ActivityTypeDTO ActivityType { get; set; }

        public LegalFormDTO LegalForm { get; set; }

        public int Size { get; set; }
    }
}

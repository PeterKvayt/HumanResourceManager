using BusinessLogicLayer.Interfaces;
using CommonClasses;
using System.ComponentModel.DataAnnotations;

namespace BusinessLogicLayer.DataTransferObjects
{
    public class CompanyDTO : IDataTransferObject
    {
        public IdType Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public ActivityTypeDTO ActivityType { get; set; }

        public LegalFormDTO LegalForm { get; set; }

        public int Size { get; set; }
    }
}

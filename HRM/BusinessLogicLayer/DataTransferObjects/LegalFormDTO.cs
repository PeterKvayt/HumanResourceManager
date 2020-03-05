using BusinessLogicLayer.Interfaces;
using CommonClasses;

namespace BusinessLogicLayer.DataTransferObjects
{
    public class LegalFormDTO : IDto
    {
        public IdType Id { get; set; }

        public string Name { get; set; }
    }
}

using BusinessLogicLayer.Interfaces;
using CommonClasses;

namespace BusinessLogicLayer.DataTransferObjects
{
    public class LegalFormDTO : IEntity
    {
        public IdType Id { get; set; }

        public string Name { get; set; }
    }
}

using BusinessLogicLayer.Interfaces;
using CommonClasses;

namespace BusinessLogicLayer.DataTransferObjects
{
    public class PositionDTO : IEntity
    {
        public IdType Id { get; set; }

        public string Name { get; set; }
    }
}

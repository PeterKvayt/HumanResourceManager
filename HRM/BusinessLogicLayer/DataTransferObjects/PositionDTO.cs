using BusinessLogicLayer.Interfaces;
using CommonClasses;

namespace BusinessLogicLayer.DataTransferObjects
{
    public class PositionDTO : IDto
    {
        public IdType Id { get; set; }

        public string Name { get; set; }
    }
}

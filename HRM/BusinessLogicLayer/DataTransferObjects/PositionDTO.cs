using BusinessLogicLayer.Interfaces;
using CommonClasses;

namespace BusinessLogicLayer.DataTransferObjects
{
    public class PositionDTO : IDataTransferObject
    {
        public IdType Id { get; set; }

        public string Name { get; set; }
    }
}

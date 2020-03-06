using BusinessLogicLayer.Interfaces;
using CommonClasses;

namespace BusinessLogicLayer.DataTransferObjects
{
    class PositionDTO : IDataTransferObject
    {
        public IdType Id { get; set; }

        public string Name { get; set; }
    }
}

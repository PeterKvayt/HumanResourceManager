using BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Converters
{
    class PositionConverter : GeneralConverter<Position, PositionDTO>, IConverter<Position, PositionDTO>
    {
        public PositionConverter(IUnitOfWork dataBase)
        {
            _dataBase = dataBase;
        }

        public Position Convert(PositionDTO dtoItem)
        {
            var resultEntityItem = new Position
            {
                Id = dtoItem.Id,
                Name = dtoItem.Name
            };

            return resultEntityItem;
        }

        public PositionDTO Convert(Position entityItem)
        {
            var resultDTO = new PositionDTO
            {
                Id = entityItem.Id,
                Name = entityItem.Name
            };

            return resultDTO;
        }
    }
}

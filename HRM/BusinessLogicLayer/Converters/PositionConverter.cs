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
    }
}

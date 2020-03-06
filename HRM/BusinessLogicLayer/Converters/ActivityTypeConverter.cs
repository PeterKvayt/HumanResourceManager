using BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;

namespace BusinessLogicLayer.Converters
{
    class ActivityTypeConverter : GeneralConverter<ActivityType, ActivityTypeDTO>, IConverter<ActivityType, ActivityTypeDTO>
    {
        public ActivityTypeConverter(IUnitOfWork dataBase)
        {
            _dataBase = dataBase;
        }
    }
}

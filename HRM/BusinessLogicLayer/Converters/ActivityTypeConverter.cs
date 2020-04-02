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

        public ActivityType Convert(ActivityTypeDTO dtoItem)
        {
            var resultEntityItem = new ActivityType
            {
                Id = dtoItem.Id,
                Name = dtoItem.Name
            };

            return resultEntityItem;
        }

        public ActivityTypeDTO Convert(ActivityType entityItem)
        {
            var resultDTO = new ActivityTypeDTO
            {
                Id = entityItem.Id,
                Name = entityItem.Name
            };

            return resultDTO;
        }
    }
}

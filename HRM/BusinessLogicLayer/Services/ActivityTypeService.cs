using System.Collections.Generic;
using BusinessLogicLayer.Converters;
using BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.Interfaces;
using CommonClasses;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;

namespace BusinessLogicLayer.Services
{
    class ActivityTypeService : GeneralService<ActivityTypeDTO, ActivityType>, IService<ActivityTypeDTO>
    {
        private IRepository<ActivityType> _repository;

        public ActivityTypeService(IUnitOfWork dataBase)
        {
            _dataBase = dataBase;
            _repository = dataBase.ActivityTypes;
            _converter = new ActivityTypeConverter(_dataBase);
        }

        public void Create(ActivityTypeDTO item)
        {
            Create(item, _repository);
        }

        public void Delete(IdType id)
        {
            Delete(id, _repository);
        }

        public ActivityTypeDTO Get(IdType id)
        {
            return Get(id, _repository);
        }

        public IEnumerable<ActivityTypeDTO> GetAll()
        {
            return GetAll(_repository);
        }

        public void Update(ActivityTypeDTO item)
        {
            Update(item, _repository);
        }
    }
}

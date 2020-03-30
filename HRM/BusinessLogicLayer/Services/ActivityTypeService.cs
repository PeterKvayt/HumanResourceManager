using System.Collections.Generic;
using BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;

namespace BusinessLogicLayer.Services
{
    class ActivityTypeService : GeneralService<ActivityTypeDTO, ActivityType>, IService<ActivityTypeDTO>
    {
        private readonly IRepository<ActivityType> _repository;

        public ActivityTypeService(IUnitOfWork dataBase, IConverter<ActivityType, ActivityTypeDTO> converter)
        {
            _dataBase = dataBase;
            _repository = dataBase.ActivityTypes;
            _converter = converter;
        }

        public void Create(ActivityTypeDTO item)
        {
            Create(item, _repository);
        }

        public void Delete(uint? id)
        {
            Delete(id, _repository);
        }

        public ActivityTypeDTO Get(uint? id)
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

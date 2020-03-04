using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.Interfaces;
using CommonClasses;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;

namespace BusinessLogicLayer.Services
{
    class ActivityTypeService : GeneralService<ActivityType, ActivityTypeDTO>, IService<ActivityTypeDTO>
    {
        private IRepository<ActivityType> _repository;

        public ActivityTypeService(IUnitOfWork dataBase)
        {
            _repository = dataBase.ActivityTypes;
        }

        public void Create(ActivityTypeDTO item)
        {
            Create(item, _repository);
        }

        public void Delete(IdType id)
        {
            Delete(id, _repository);
        }

        public bool Exists(IdType id)
        {
            return Exists(id, _repository);
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

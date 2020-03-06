using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogicLayer.Converters;
using BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.DataTransferObjects;
using CommonClasses;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;

namespace BusinessLogicLayer.Services
{
    class ActivityTypeService : GeneralService<ActivityTypePLM, ActivityTypeDTO, ActivityType>, IService<ActivityTypePLM>
    {
        private IRepository<ActivityType> _repository;

        public ActivityTypeService(IUnitOfWork dataBase)
        {
            _dataBase = dataBase;
            _repository = dataBase.ActivityTypes;
            _converter = new ActivityTypeConverter(_dataBase);
        }

        public void Create(ActivityTypePLM item)
        {
            Create(item, _repository);
        }

        public void Delete(IdType id)
        {
            Delete(id, _repository);
        }

        public ActivityTypePLM Get(IdType id)
        {
            return Get(id, _repository);
        }

        public IEnumerable<ActivityTypePLM> GetAll()
        {
            return GetAll(_repository);
        }

        public void Update(ActivityTypePLM item)
        {
            Update(item, _repository);
        }
    }
}

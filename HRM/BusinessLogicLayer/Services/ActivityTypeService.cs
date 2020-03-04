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
        public ActivityTypeService(IUnitOfWork dataBase)
        {
            _dataBase = dataBase;
        }

        public void Create(ActivityTypeDTO item)
        {
            Create(item, _dataBase.ActivityTypes);
        }

        public void Delete(IdType id)
        {
            Delete(id, _dataBase.ActivityTypes);
        }

        public bool Exists(IdType id)
        {
            return Exists(id, _dataBase.ActivityTypes);
        }

        public ActivityTypeDTO Get(IdType id)
        {
            return Get(id, _dataBase.ActivityTypes);
        }

        public IEnumerable<ActivityTypeDTO> GetAll()
        {
            return GetAll(_dataBase.ActivityTypes);
        }

        public void Update(ActivityTypeDTO item)
        {
            Update(item, _dataBase.ActivityTypes);
        }
    }
}

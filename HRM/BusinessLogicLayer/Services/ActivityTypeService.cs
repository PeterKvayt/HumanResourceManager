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
            ActivityType activityType = ConvertToEntity(item);

            try
            {
                _dataBase.ActivityTypes.Create(activityType);
            }
            catch (Exception)
            {
                // ToDo: exception
                throw;
            }
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
            try
            {
                ActivityType activityType = _dataBase.ActivityTypes.Get(id);

                ActivityTypeDTO resultActivityTypeDTO = ConvertToDTO(activityType);

                return resultActivityTypeDTO;
            }
            catch (Exception)
            {
                // ToDo: exception
                throw;
            }
        }

        public IEnumerable<ActivityTypeDTO> GetAll()
        {
            try
            {
                IEnumerable<ActivityType> activityTypesCollection = _dataBase.ActivityTypes.GetAll();

                List<ActivityTypeDTO> resultActivityTypes = new List<ActivityTypeDTO> { };

                foreach (var item in activityTypesCollection)
                {
                    ActivityTypeDTO activityType = ConvertToDTO(item);

                    resultActivityTypes.Add(activityType);
                }

                return resultActivityTypes;
            }
            catch (Exception)
            {
                // ToDo: exception
                throw;
            }
        }

        public void Update(ActivityTypeDTO item)
        {
            ActivityType activityType = ConvertToEntity(item);

            try
            {
                _dataBase.ActivityTypes.Update(activityType);
            }
            catch (Exception)
            {
                // ToDo: exception
                throw;
            }
        }
    }
}

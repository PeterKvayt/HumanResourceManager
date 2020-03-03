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
    class ActivityTypeService : GeneralService<ActivityTypeDTO>, IService<ActivityTypeDTO>
    {
        public ActivityTypeService(IUnitOfWork dataBase)
        {
            _dataBase = dataBase;
        }

        public void Create(ActivityTypeDTO item)
        {
            ActivityType activityType = new ActivityType
            {
                Id = item.Id,
                Name = item.Name
            };

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

        public void Delete(ActivityTypeDTO item)
        {
            try
            {
                _dataBase.ActivityTypes.Delete(item.Id);
            }
            catch (Exception)
            {
                // ToDo: exception
                throw;
            }
        }

        public bool Exists(IdType id)
        {
            try
            {
                return _dataBase.ActivityTypes.Exists(id);
            }
            catch (Exception)
            {
                // ToDo: exception
                throw;
            }
        }

        public ActivityTypeDTO Get(IdType id)
        {
            try
            {
                ActivityType activityType = _dataBase.ActivityTypes.Get(id);

                ActivityTypeDTO resultActivityTypeDTO = new ActivityTypeDTO
                {
                    Id = activityType.Id,
                    Name = activityType.Name
                };

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
                    ActivityTypeDTO activityType = new ActivityTypeDTO
                    {
                        Id = item.Id,
                        Name = item.Name
                    };

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
            ActivityType activityType = new ActivityType
            {
                Id = item.Id,
                Name = item.Name
            };

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

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
            ActivityType activityType = ConvertToActivityType(item);

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

                ActivityTypeDTO resultActivityTypeDTO = ConvertToActivityTypeDTO(activityType);

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
                    ActivityTypeDTO activityType = ConvertToActivityTypeDTO(item);

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
            ActivityType activityType = ConvertToActivityType(item);

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

        /// <summary>
        /// Сопостовляет ActivityTypeDTO c ActivityType
        /// </summary>
        /// <param name="item">Экземпляр ActivityTypeDTO</param>
        /// <returns>Экземпляр ActivityType</returns>
        private ActivityType ConvertToActivityType(ActivityTypeDTO item)
        {
            ActivityType activityType = new ActivityType
            {
                Id = item.Id,
                Name = item.Name
            };

            return activityType;
        }

        /// <summary>
        /// Сопостовляет ActivityType c ActivityTypeDTO
        /// </summary>
        /// <param name="item">Экземпляр ActivityTypeDTO</param>
        /// <returns>Экземпляр ActivityType</returns>
        private ActivityTypeDTO ConvertToActivityTypeDTO(ActivityType item)
        {
            ActivityTypeDTO activityTypeDto = new ActivityTypeDTO
            {
                Id = item.Id,
                Name = item.Name
            };

            return activityTypeDto;
        }
    }
}

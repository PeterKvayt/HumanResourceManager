using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.Interfaces;
using CommonClasses;
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
            try
            {
                _dataBase.ActivityTypes.Create();
            }
            catch (Exception)
            {
                // ToDo: exception
                throw;
            }
        }

        public void Delete(IdType id)
        {
            throw new NotImplementedException();
        }

        public bool Exists(IdType id)
        {
            throw new NotImplementedException();
        }

        public ActivityTypeDTO Get(IdType id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ActivityTypeDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(ActivityTypeDTO item)
        {
            throw new NotImplementedException();
        }
    }
}

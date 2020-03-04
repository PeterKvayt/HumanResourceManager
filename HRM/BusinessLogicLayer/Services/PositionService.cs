using BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.Interfaces;
using CommonClasses;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Services
{
    class PositionService : GeneralService<Position, PositionDTO>, IService<PositionDTO>
    {
        public PositionService(IUnitOfWork dataBase)
        {
            _dataBase = dataBase;
        }

        public void Create(PositionDTO item)
        {
            Create(item, _dataBase.Positions);
        }

        public void Delete(IdType id)
        {
            Delete(id, _dataBase.Positions);
        }

        public bool Exists(IdType id)
        {
            return Exists(id, _dataBase.Positions);
        }

        public PositionDTO Get(IdType id)
        {
            return Get(id, _dataBase.Positions);
        }

        public IEnumerable<PositionDTO> GetAll()
        {
            return GetAll(_dataBase.Positions);
        }

        public void Update(PositionDTO item)
        {
            Update(item, _dataBase.Positions);
        }
    }
}

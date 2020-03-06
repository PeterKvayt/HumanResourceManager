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
    class PositionService : GeneralService<PositionDTO, Position>, IService<PositionDTO>
    {
        private IRepository<Position> _repository;

        public PositionService(IUnitOfWork dataBase)
        {
            _repository = dataBase.Positions;
        }

        public void Create(PositionDTO item)
        {
            Create(item, _repository);
        }

        public void Delete(IdType id)
        {
            Delete(id, _repository);
        }

        public PositionDTO Get(IdType id)
        {
            return Get(id, _repository);
        }

        public IEnumerable<PositionDTO> GetAll()
        {
            return GetAll(_repository);
        }

        public void Update(PositionDTO item)
        {
            Update(item, _repository);
        }
    }
}

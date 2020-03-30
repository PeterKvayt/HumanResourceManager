using BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System.Collections.Generic;

namespace BusinessLogicLayer.Services
{
    class PositionService : GeneralService<PositionDTO, Position>, IService<PositionDTO>
    {
        private readonly IRepository<Position> _repository;

        public PositionService(IUnitOfWork dataBase, IConverter<Position, PositionDTO> converter)
        {
            _dataBase = dataBase;
            _repository = dataBase.Positions;
            _converter = converter;
        }

        public void Create(PositionDTO item)
        {
            Create(item, _repository);
        }

        public void Delete(uint? id)
        {
            Delete(id, _repository);
        }

        public PositionDTO Get(uint? id)
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

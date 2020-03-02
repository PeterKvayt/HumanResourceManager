using CommonClasses;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System.Collections.Generic;

namespace DataAccessLayer.Repositories
{
    class PositionRepository : GeneralRepository<Position>, IRepository<Position>
    {
        private IDataAccessLayer<Position> _context;

        public PositionRepository(IHrmContext inputСontext)
        {
            _context = inputСontext.PositionContext;
        }

        public void Create(Position item)
        {
            Create(item, _context);
        }

        public void Delete(IdType id)
        {
            Delete(id, _context);
        }

        public bool Exists(IdType id)
        {
            return Exists(id, _context);
        }

        public Position Get(IdType id)
        {
            return Get(id, _context);
        }

        public IEnumerable<Position> GetAll()
        {
            return GetAll(_context);
        }

        public void Update(Position item)
        {
            Update(item, _context);
        }
    }
}

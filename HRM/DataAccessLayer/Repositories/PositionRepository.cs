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

        public void Delete(Position item)
        {
            Delete(item, _context);
        }

        public bool Exists(Position item)
        {
            return Exists(item, _context);
        }

        public Position Get(Position item)
        {
            return Get(item, _context);
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

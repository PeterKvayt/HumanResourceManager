using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;

namespace DataAccessLayer.Repositories
{
    class PositionRepository : GeneralRepository<Position>, IRepository<Position>
    {
        public PositionRepository(IHrmContext inputСontext)
        {
            _context = inputСontext.PositionContext;
        }
    }
}

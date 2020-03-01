using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;

namespace DataAccessLayer.Repositories
{
    class ActivityTypeRepository : GeneralRepository<ActivityType>, IRepository<ActivityType>
    {
        public ActivityTypeRepository(IHrmContext inputСontext)
        {
            _context = inputСontext.ActivityTypeContext;
        }
    }
}

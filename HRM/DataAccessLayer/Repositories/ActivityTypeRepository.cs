using System.Collections.Generic;
using CommonClasses;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;

namespace DataAccessLayer.Repositories
{
    class ActivityTypeRepository : GeneralRepository<ActivityType>, IRepository<ActivityType>
    {
        private IDataAccessLayer<ActivityType> _context;

        public ActivityTypeRepository(IHrmContext inputСontext)
        {
            _context = inputСontext.ActivityTypeContext;
        }

        public void Create(ActivityType item)
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

        public ActivityType Get(IdType id)
        {
            return Get(id, _context);
        }

        public IEnumerable<ActivityType> GetAll()
        {
            return GetAll(_context);
        }

        public void Update(ActivityType item)
        {
            Update(item, _context);
        }
    }
}

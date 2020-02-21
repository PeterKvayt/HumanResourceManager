using DataAccessLayer.AssistantClasses;
using DataAccessLayer.DataContext;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Repositories
{
    class ActivityTypeRepository : IRepository<ActivityType>
    {
        private readonly HRMContext context;

        public ActivityTypeRepository(HRMContext inputСontext)
        {
            context = inputСontext;
        }

        public void Create(ActivityType newActivityType)
        {
            context.ActivityTypeContext.Create(newActivityType);
        }

        public void Delete(IdType id)
        {
        }

        public ActivityType Get(IdType id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ActivityType> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(ActivityType item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ActivityType> Find(Func<ActivityType, bool> predicate)
        {
            throw new NotImplementedException();
        }
    }
}

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
        private readonly IDataAccessLayer<ActivityType> context;

        public ActivityTypeRepository(HRMContext inputСontext)
        {
            context = inputСontext.ActivityTypeContext;
        }

        public void Create(ActivityType newActivityType)
        {
            context.Create(newActivityType);
        }

        public void Delete(IdType id)
        {
            context.Delete(id);
        }

        public ActivityType Get(IdType id)
        {
            return context.Get(id);
        }

        public IEnumerable<ActivityType> GetAll()
        {
            return context.GetAll();
        }

        public void Update(ActivityType item)
        {
            context.Update(item);
        }

        public IEnumerable<ActivityType> Find(Func<ActivityType, bool> predicate)
        {
            // ToDo: find
            throw new NotImplementedException();
        }
    }
}

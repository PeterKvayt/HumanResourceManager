    using DataAccessLayer.Classes;
    using DataAccessLayer.Entities;
    using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.DataContext
{
    class ActivityTypeDataAccessLayer : IDataAccessLayer<ActivityType>
    {
        public void Create(ActivityType item)
        {
            throw new NotImplementedException();
        }

        public void Delete(IdType id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ActivityType> Find(Func<ActivityType, bool> predicate)
        {
            throw new NotImplementedException();
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
    }
}

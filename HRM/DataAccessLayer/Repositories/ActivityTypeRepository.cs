using DataAccessLayer.AssistantClasses;
using DataAccessLayer.DataContext;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Repositories
{
    class ActivityTypeRepository : GeneralRepository<ActivityType>, IRepository<ActivityType>
    {
        public ActivityTypeRepository(IHRMContext inputСontext)
        {
            context = inputСontext.ActivityTypeContext;
        }
    }
}

using DataAccessLayer.AssistantClasses;
using DataAccessLayer.DataContext;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Repositories
{
    class PositionRepository : GeneralRepository<Position>, IRepository<Position>
    {
        public PositionRepository(IHrmContext inputСontext)
        {
            context = inputСontext.PositionContext;
        }
    }
}

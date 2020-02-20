using DataAccessLayer.AssistantClasses;
using DataAccessLayer.DataContext;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Repositories
{
    class PositionRepository : IRepository<Position>
    {
        private readonly HRMContext context;

        public PositionRepository(HRMContext inputСontext)
        {
            context = inputСontext;
        }

        public void Create(Position item)
        {
            throw new NotImplementedException();
        }

        public void Delete(IdType id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Position> Find(Func<Position, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Position Get(IdType id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Position> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Position item)
        {
            throw new NotImplementedException();
        }
    }
}

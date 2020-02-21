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
        private readonly IDataAccessLayer<Position> context;

        public PositionRepository(HRMContext inputСontext)
        {
            context = inputСontext.PositionContext;
        }

        public void Create(Position newPosition)
        {
            context.Create(newPosition);
        }

        public void Delete(IdType id)
        {
            context.Delete(id);
        }

        public Position Get(IdType id)
        {
            return context.Get(id);
        }

        public IEnumerable<Position> GetAll()
        {
            return context.GetAll();
        }

        public void Update(Position item)
        {
            context.Update(item);
        }

        public IEnumerable<Position> Find(Func<Position, bool> predicate)
        {
            // ToDo: find
            throw new NotImplementedException();
        }
    }
}

using DataAccessLayer.Classes;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;

namespace DataAccessLayer.DataContext
{
    class PositionDataAccessLayer : IDataAccessLayer<Position>
    {
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

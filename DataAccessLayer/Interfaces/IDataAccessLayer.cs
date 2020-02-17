using DataAccessLayer.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Interfaces
{
    interface IDataAccessLayer<T> where T : class
    {
        IEnumerable<T> GetAll();

        T Get(IdType id);

        void Create(T item);

        void Update(T item);

        void Delete(IdType id);

        IEnumerable<T> Find(Func<T, Boolean> predicate);
    }
}
}

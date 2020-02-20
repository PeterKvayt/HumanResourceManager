using DataAccessLayer.AssistantClasses;
using System;
using System.Collections.Generic;

namespace DataAccessLayer.Interfaces
{
    interface IDataAccessLayer<T> where T : class
    {
        IEnumerable<T> GetAll(string storedProcedureName);

        T Get(IdType id, string storedProcedureName);

        void Create(T item);

        void Update(T item);

        void Delete(IdType id, string storedProcedureName);

        IEnumerable<T> Find(Func<T, Boolean> predicate);
    }
}


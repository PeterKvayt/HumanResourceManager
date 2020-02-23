using DataAccessLayer.AssistantClasses;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Repositories
{
    abstract class GeneralRepository<T> where T: class
    {
        protected IDataAccessLayer<T> context;

        public virtual void Create(T newItem)
        {
            context.Create(newItem);
        }

        public virtual void Delete(IdType id)
        {
            context.Delete(id);
        }

        public virtual T Get(IdType id)
        {
            return context.Get(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return context.GetAll();
        }

        public virtual void Update(T item)
        {
            context.Update(item);
        }
    }
}

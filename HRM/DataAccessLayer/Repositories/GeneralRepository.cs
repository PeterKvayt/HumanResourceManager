using DataAccessLayer.AssistantClasses;
using DataAccessLayer.Interfaces;
using System.Collections.Generic;

namespace DataAccessLayer.Repositories
{
    /// <summary>
    /// Класс отвечает за общую реализацию классов, реализующих интерфейс IRepository
    /// </summary>
    /// <typeparam name="T">Конкретный тип реализуемого класса</typeparam>
    abstract class GeneralRepository<T> where T: class
    {
        protected IDataAccessLayer<T> context;

        public virtual void Create(T item)
        {
            context.Create(item);
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

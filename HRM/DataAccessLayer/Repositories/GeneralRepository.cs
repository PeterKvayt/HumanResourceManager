using CommonClasses;
using DataAccessLayer.Interfaces;
using ExceptionClasses.Loggers;
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
            try
            {
                context.Create(item);
            }
            catch (System.Exception)
            {
                string EXCEPTION_MESSAGE = $"Ошибка создания экземпляра класса {typeof(T).ToString()} в классе GeneralRepository!";

                ExceptionLogger.LogError(EXCEPTION_MESSAGE);

                throw;
            }
        }

        public virtual void Delete(IdType id)
        {
            try
            {
                context.Delete(id);
            }
            catch (System.Exception)
            {
                string EXCEPTION_MESSAGE = $"Ошибка удаления экземпляра класса {typeof(T).ToString()} в классе GeneralRepository!";

                ExceptionLogger.LogError(EXCEPTION_MESSAGE);

                throw;
            }
        }

        public virtual T Get(IdType id)
        {
            try
            {
                return context.Get(id);
            }
            catch (System.Exception)
            {
                string EXCEPTION_MESSAGE = $"Ошибка получения экземпляра класса {typeof(T).ToString()} в классе GeneralRepository!";

                ExceptionLogger.LogError(EXCEPTION_MESSAGE);

                throw;
            }
        }

        public virtual IEnumerable<T> GetAll()
        {
            try
            {
                return context.GetAll();
            }
            catch (System.Exception)
            {
                string EXCEPTION_MESSAGE = $"Ошибка получения всех экземпляров класса {typeof(T).ToString()} в классе GeneralRepository!";

                ExceptionLogger.LogError(EXCEPTION_MESSAGE);

                throw;
            }
        }

        public virtual void Update(T item)
        {
            try
            {
                context.Update(item);
            }
            catch (System.Exception)
            {
                string EXCEPTION_MESSAGE = $"Ошибка обновления экземпляра класса {typeof(T).ToString()} в классе GeneralRepository!";

                ExceptionLogger.LogError(EXCEPTION_MESSAGE);

                throw;
            }
        }
    }
}

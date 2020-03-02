using CommonClasses;
using DataAccessLayer.Interfaces;
using ExceptionClasses.Loggers;
using System.Collections.Generic;
using System;

namespace DataAccessLayer.Repositories
{
    /// <summary>
    /// Класс отвечает за общую реализацию классов, реализующих интерфейс IRepository
    /// </summary>
    /// <typeparam name="T">Конкретный тип реализуемого класса</typeparam>
    abstract class GeneralRepository<T> where T: class
    {
        public virtual void Create(T item, IDataAccessLayer<T> context)
        {
            try
            {
                context.Create(item);
            }
            catch (Exception)
            {
                string EXCEPTION_MESSAGE = $"Ошибка создания экземпляра класса {typeof(T).ToString()} в классе GeneralRepository!";

                ExceptionLogger.LogError(EXCEPTION_MESSAGE);

                throw;
            }
        }

        public virtual void Delete(IdType id, IDataAccessLayer<T> context)
        {
            try
            {
                context.Delete(id);
            }
            catch (Exception)
            {
                string EXCEPTION_MESSAGE = $"Ошибка удаления экземпляра класса {typeof(T).ToString()} в классе GeneralRepository!";

                ExceptionLogger.LogError(EXCEPTION_MESSAGE);

                throw;
            }
        }

        public virtual T Get(IdType id, IDataAccessLayer<T> context)
        {
            try
            {
                return context.Get(id);
            }
            catch (Exception)
            {
                string EXCEPTION_MESSAGE = $"Ошибка получения экземпляра класса {typeof(T).ToString()} в классе GeneralRepository!";

                ExceptionLogger.LogError(EXCEPTION_MESSAGE);

                throw;
            }
        }

        public virtual IEnumerable<T> GetAll(IDataAccessLayer<T> context)
        {
            try
            {
                return context.GetAll();
            }
            catch (Exception)
            {
                string EXCEPTION_MESSAGE = $"Ошибка получения всех экземпляров класса {typeof(T).ToString()} в классе GeneralRepository!";

                ExceptionLogger.LogError(EXCEPTION_MESSAGE);

                throw;
            }
        }

        public virtual void Update(T item, IDataAccessLayer<T> context)
        {
            try
            {
                context.Update(item);
            }
            catch (Exception)
            {
                string EXCEPTION_MESSAGE = $"Ошибка обновления экземпляра класса {typeof(T).ToString()} в классе GeneralRepository!";

                ExceptionLogger.LogError(EXCEPTION_MESSAGE);

                throw;
            }
        }

        public virtual bool Exists(IdType id, IDataAccessLayer<T> context)
        {
            try
            {
                return context.Exists(id);
            }
            catch (Exception)
            {
                string EXCEPTION_MESSAGE = $"Ошибка проверки существования записи об экземпляре класса {typeof(T).ToString()} в классе GeneralRepository!";

                ExceptionLogger.LogError(EXCEPTION_MESSAGE);

                throw;
            }
        }
    }
}

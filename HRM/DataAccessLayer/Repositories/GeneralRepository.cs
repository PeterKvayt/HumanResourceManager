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
    /// <typeparam name="EntityType">Конкретный тип реализуемого класса</typeparam>
    abstract class GeneralRepository<EntityType> where EntityType: class
    {
        public virtual void Create(EntityType item, IDataAccessLayer<EntityType> context)
        {
            try
            {
                context.Create(item);
            }
            catch (Exception)
            {
                string EXCEPTION_MESSAGE = $"Ошибка создания экземпляра класса {typeof(EntityType).ToString()} в классе GeneralRepository!";

                ExceptionLogger.LogError(EXCEPTION_MESSAGE);

                throw;
            }
        }

        public virtual void Delete(IdType id, IDataAccessLayer<EntityType> context)
        {
            try
            {
                context.Delete(id);
            }
            catch (Exception)
            {
                string EXCEPTION_MESSAGE = $"Ошибка удаления экземпляра класса {typeof(EntityType).ToString()} в классе GeneralRepository!";

                ExceptionLogger.LogError(EXCEPTION_MESSAGE);

                throw;
            }
        }

        public virtual EntityType Get(IdType id, IDataAccessLayer<EntityType> context)
        {
            try
            {
                return context.Get(id);
            }
            catch (Exception)
            {
                string EXCEPTION_MESSAGE = $"Ошибка получения экземпляра класса {typeof(EntityType).ToString()} в классе GeneralRepository!";

                ExceptionLogger.LogError(EXCEPTION_MESSAGE);

                throw;
            }
        }

        public virtual IEnumerable<EntityType> GetAll(IDataAccessLayer<EntityType> context)
        {
            try
            {
                return context.GetAll();
            }
            catch (Exception)
            {
                string EXCEPTION_MESSAGE = $"Ошибка получения всех экземпляров класса {typeof(EntityType).ToString()} в классе GeneralRepository!";

                ExceptionLogger.LogError(EXCEPTION_MESSAGE);

                throw;
            }
        }

        public virtual void Update(EntityType item, IDataAccessLayer<EntityType> context)
        {
            try
            {
                context.Update(item);
            }
            catch (Exception)
            {
                string EXCEPTION_MESSAGE = $"Ошибка обновления экземпляра класса {typeof(EntityType).ToString()} в классе GeneralRepository!";

                ExceptionLogger.LogError(EXCEPTION_MESSAGE);

                throw;
            }
        }

        public virtual bool Exists(IdType id, IDataAccessLayer<EntityType> context)
        {
            try
            {
                return context.Exists(id);
            }
            catch (Exception)
            {
                string EXCEPTION_MESSAGE = $"Ошибка проверки существования записи об экземпляре класса {typeof(EntityType).ToString()} в классе GeneralRepository!";

                ExceptionLogger.LogError(EXCEPTION_MESSAGE);

                throw;
            }
        }
    }
}

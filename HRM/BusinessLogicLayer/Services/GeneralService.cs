using BusinessLogicLayer.Interfaces;
using CommonClasses;
using DataAccessLayer.Interfaces;
using ExceptionClasses.Exceptions;
using ExceptionClasses.Loggers;
using System;
using System.Collections.Generic;

namespace BusinessLogicLayer.Services
{
    abstract class GeneralService<DataTransferObject, EntityType> 
        where DataTransferObject : class, IDataTransferObject, new()
        where EntityType: class, new()
    {
        protected IUnitOfWork _dataBase;

        protected IConverter<EntityType, DataTransferObject> _converter;

        protected virtual void Create(DataTransferObject item, IRepository<EntityType> repository)
        {
            EntityType entity = null;
            try
            {
                entity = _converter.Convert(item);
            }
            catch (Exception)
            {
                string EXCEPTION_MESSAGE = $"Ошибка конвертирования класса {typeof(DataTransferObject).ToString()} в {typeof(EntityType).ToString()} в классе GeneralService";

                ExceptionLogger.LogError(EXCEPTION_MESSAGE);

                throw;
            }

            try
            {
                repository.Create(entity);
            }
            catch (Exception)
            {
                string EXCEPTION_MESSAGE = $"Ошибка создания записи в базе данных экземпляра класса {typeof(EntityType).ToString()} в классе GeneralService";

                ExceptionLogger.LogError(EXCEPTION_MESSAGE);

                throw;
            }
        }

        protected virtual void Delete(IdType id, IRepository<EntityType> repository)
        {
            if ( !Exists(id, repository) )
            {
                string EXCEPTION_MESSAGE = $"Запрос с клиента на удаление несуществующей записи в базе данных экземпляра класса {typeof(EntityType).ToString()} с Id = {id.Identificator.ToString()} в классе GeneralService";

                ExceptionLogger.LogWarn(EXCEPTION_MESSAGE);

                throw new ClientException();
            }

            try
            {
                repository.Delete(id);
            }
            catch (Exception)
            {
                string EXCEPTION_MESSAGE = $"Ошибка удаления записи в базе данных экземпляра класса {typeof(EntityType).ToString()} с Id = {id.Identificator.ToString()} в классе GeneralService";

                ExceptionLogger.LogError(EXCEPTION_MESSAGE);

                throw;
            }
        }

        protected virtual DataTransferObject Get(IdType id, IRepository<EntityType> repository)
        {
            if (!Exists(id, repository))
            {
                string EXCEPTION_MESSAGE = $"Запрос с клиента на получение несуществующей записи из базы данных экземпляра класса {typeof(EntityType).ToString()} с Id = {id.Identificator.ToString()} в классе GeneralService";

                ExceptionLogger.LogWarn(EXCEPTION_MESSAGE);

                throw new ClientException();
            }

            EntityType entity = null;
            try
            {
                entity = repository.Get(id);
            }
            catch (Exception ex)
            {
                string EXCEPTION_MESSAGE = $"Ошибка получения записи из базе данных экземпляра класса {typeof(EntityType).ToString()} с Id = {id.Identificator.ToString()} в классе GeneralService";

                ExceptionLogger.LogError(EXCEPTION_MESSAGE);

                throw;
            }

            try
            {
                DataTransferObject resultEntityDTO = _converter.Convert(entity);

                return resultEntityDTO;
            }
            catch (Exception)
            {
                string EXCEPTION_MESSAGE = $"Ошибка конвертирования класса {typeof(EntityType).ToString()} в {typeof(DataTransferObject).ToString()} в классе GeneralService";

                ExceptionLogger.LogError(EXCEPTION_MESSAGE);

                throw;
            }
        }

        protected virtual IEnumerable<DataTransferObject> GetAll(IRepository<EntityType> repository)
        {
            IEnumerable<EntityType> entityCollection = null;
            try
            {
                entityCollection = repository.GetAll();
            }
            catch (Exception)
            {
                string EXCEPTION_MESSAGE = $"Ошибка получения всех записей из базы данных класса {typeof(EntityType).ToString()} в классе GeneralService";

                ExceptionLogger.LogError(EXCEPTION_MESSAGE);

                throw;
            }

            List<DataTransferObject> resultDtoCollection = new List<DataTransferObject> { };
            try
            {
                foreach (var entityItem in entityCollection)
                {
                    DataTransferObject dataTransferObject = _converter.Convert(entityItem);
                    resultDtoCollection.Add(dataTransferObject);
                }

                return resultDtoCollection;
            }
            catch (Exception)
            {
                string EXCEPTION_MESSAGE = $"Ошибка конвертирования класса {typeof(EntityType).ToString()} в {typeof(DataTransferObject).ToString()} в классе GeneralService";

                ExceptionLogger.LogError(EXCEPTION_MESSAGE);

                throw;
            }
        }

        protected virtual void Update(DataTransferObject item, IRepository<EntityType> repository)
        {
            if ( !Exists(item.Id, repository) )
            {
                string EXCEPTION_MESSAGE = $"Запрос с клиента на обновление несуществующей записи в базе данных экземпляра класса {typeof(EntityType).ToString()} с Id = {item.Id.Identificator.ToString()} в классе GeneralService";

                ExceptionLogger.LogWarn(EXCEPTION_MESSAGE);

                throw new ClientException();
            }

            EntityType resultDataBaseEntity = null;
            try
            {
                resultDataBaseEntity = _converter.Convert(item);
            }
            catch (Exception)
            {
                string EXCEPTION_MESSAGE = $"Ошибка конвертирования класса {typeof(DataTransferObject).ToString()} в {typeof(EntityType).ToString()} в классе GeneralService";

                ExceptionLogger.LogError(EXCEPTION_MESSAGE);

                throw;
            }


            try
            {
                repository.Update(resultDataBaseEntity);
            }
            catch (Exception)
            {
                string EXCEPTION_MESSAGE = $"Ошибка обновления записи экземпляра класса {typeof(EntityType).ToString()} в базе данных в классе GeneralService";

                ExceptionLogger.LogError(EXCEPTION_MESSAGE);

                throw;
            }
        }

        private bool Exists(IdType id, IRepository<EntityType> repository)
        {
            try
            {
                return repository.Exists(id);
            }
            catch (Exception)
            {
                string EXCEPTION_MESSAGE = $"Ошибка проверки существования записи экземпляра класса {typeof(EntityType).ToString()} с Id = {id.Identificator.ToString()} в базе данных в классе GeneralService";

                ExceptionLogger.LogError(EXCEPTION_MESSAGE);

                throw;
            }
        }
    }
}

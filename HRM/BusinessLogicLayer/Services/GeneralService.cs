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
            catch (Exception exception)
            {
                ExceptionLogger.Log(exception);

                throw;
            }

            try
            {
                repository.Create(entity);
            }
            catch (Exception exception)
            {
                ExceptionLogger.Log(exception);

                throw;
            }
        }

        protected virtual void Delete(IdType id, IRepository<EntityType> repository)
        {
            if ( !Exists(id, repository) )
            {
                string EXCEPTION_MESSAGE = $"Запрос с клиента на удаление несуществующей записи в базе данных экземпляра класса {typeof(EntityType).ToString()} с Id = {id.Identificator.ToString()} в классе GeneralService";

                ExceptionLogger.Log(EXCEPTION_MESSAGE, typeof(GeneralService<DataTransferObject, EntityType>).Name, "Delete");

                throw new ClientException();
            }

            try
            {
                repository.Delete(id);
            }
            catch (Exception exception)
            {
                ExceptionLogger.Log(exception);

                throw;
            }
        }

        protected virtual DataTransferObject Get(IdType id, IRepository<EntityType> repository)
        {
            if (!Exists(id, repository))
            {
                string EXCEPTION_MESSAGE = $"Запрос с клиента на получение несуществующей записи из базы данных экземпляра класса {typeof(EntityType).ToString()} с Id = {id.Identificator.ToString()} в классе GeneralService";

                ExceptionLogger.Log(EXCEPTION_MESSAGE, typeof(GeneralService<DataTransferObject, EntityType>).Name, "Get");

                throw new ClientException();
            }

            EntityType entity = null;
            try
            {
                entity = repository.Get(id);
            }
            catch (Exception exception)
            {
                ExceptionLogger.Log(exception);

                throw;
            }

            try
            {
                DataTransferObject resultEntityDTO = _converter.Convert(entity);

                return resultEntityDTO;
            }
            catch (Exception exception)
            {
                ExceptionLogger.Log(exception);

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
            catch (Exception exception)
            {
                ExceptionLogger.Log(exception);

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
            catch (Exception exception)
            {
                ExceptionLogger.Log(exception);

                throw;
            }
        }

        protected virtual void Update(DataTransferObject item, IRepository<EntityType> repository)
        {
            if ( !Exists(item.Id, repository) )
            {
                string EXCEPTION_MESSAGE = $"Запрос с клиента на обновление несуществующей записи в базе данных экземпляра класса {typeof(EntityType).ToString()} с Id = {item.Id.Identificator.ToString()} в классе GeneralService";

                ExceptionLogger.Log(EXCEPTION_MESSAGE, typeof(GeneralService<DataTransferObject, EntityType>).Name, "Update");

                throw new ClientException();
            }

            EntityType resultDataBaseEntity = null;
            try
            {
                resultDataBaseEntity = _converter.Convert(item);
            }
            catch (Exception exception)
            {
                ExceptionLogger.Log(exception);

                throw;
            }


            try
            {
                repository.Update(resultDataBaseEntity);
            }
            catch (Exception exception)
            {
                ExceptionLogger.Log(exception);

                throw;
            }
        }

        private bool Exists(IdType id, IRepository<EntityType> repository)
        {
            try
            {
                return repository.Exists(id);
            }
            catch (Exception exception)
            {
                ExceptionLogger.Log(exception);

                throw;
            }
        }
    }
}

using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Mapper;
using CommonClasses;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;

namespace BusinessLogicLayer.Services
{
    abstract class GeneralService<DataTransferObject, DataBaseEntity> 
        where DataTransferObject : class, IDataTransferObject, new()
        where DataBaseEntity: class, new()
    {
        protected IUnitOfWork _dataBase;

        protected IConverter<DataBaseEntity, DataTransferObject> _converter;

        protected virtual void Create(DataTransferObject item, IRepository<DataBaseEntity> repository)
        {
            DataBaseEntity entity = null;
            try
            {
                entity = _converter.Convert(item);
            }
            catch (Exception)
            {
                // ToDo: exception
                throw;
            }

            try
            {
                repository.Create(entity);
            }
            catch (Exception)
            {
                // ToDo: exception
                throw;
            }
        }

        protected virtual void Delete(IdType id, IRepository<DataBaseEntity> repository)
        {
            if ( !Exists(id, repository) )
            {
                // ToDo: exception for user
                throw new Exception();
            }

            try
            {
                repository.Delete(id);
            }
            catch (Exception)
            {
                // ToDo: exception
                throw;
            }
        }

        protected virtual DataTransferObject Get(IdType id, IRepository<DataBaseEntity> repository)
        {
            DataBaseEntity entity = null;
            try
            {
                entity = repository.Get(id);
            }
            catch (Exception)
            {
                // ToDo: exception
                throw;
            }

            try
            {
                DataTransferObject resultEntityDTO = _converter.Convert(entity);

                return resultEntityDTO;
            }
            catch (Exception)
            {
                // ToDo: exception
                throw;
            }
        }

        protected virtual IEnumerable<DataTransferObject> GetAll(IRepository<DataBaseEntity> repository)
        {
            IEnumerable<DataBaseEntity> entityCollection = null;
            try
            {
                entityCollection = repository.GetAll();
            }
            catch (Exception)
            {
                // ToDo: exception
                throw;
            }

            try
            {
                List<DataTransferObject> resultDtoCollection = new List<DataTransferObject> { };

                foreach (var entityItem in entityCollection)
                {
                    DataTransferObject dataTransferObject = _converter.Convert(entityItem);
                    resultDtoCollection.Add(dataTransferObject);
                }

                return resultDtoCollection;
            }
            catch (Exception)
            {
                // ToDo: exception
                throw;
            }
        }

        protected virtual void Update(DataTransferObject item, IRepository<DataBaseEntity> repository)
        {
            if ( !Exists(item.Id, repository) )
            {
                // ToDo: exception for user
                throw new Exception();
            }

            DataBaseEntity resultDataBaseEntity = null;
            try
            {
                resultDataBaseEntity = _converter.Convert(item);
            }
            catch (Exception)
            {
                // ToDo: exception
                throw;
            }


            try
            {
                repository.Update(resultDataBaseEntity);
            }
            catch (Exception)
            {
                // ToDo: exception
                throw;
            }
        }

        private bool Exists(IdType id, IRepository<DataBaseEntity> repository)
        {
            try
            {
                return repository.Exists(id);
            }
            catch (Exception)
            {
                // ToDo: exception
                throw;
            }
        }
    }
}

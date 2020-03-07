using BusinessLogicLayer.Interfaces;
using CommonClasses;
using DataAccessLayer.Interfaces;
using ExceptionClasses.Loggers;
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
                string EXCEPTION_MESSAGE = $"Ошибка конвертирования класса {typeof(DataTransferObject).ToString()} в {typeof(DataBaseEntity).ToString()} в классе GeneralService";

                ExceptionLogger.LogError(EXCEPTION_MESSAGE);

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
                string EXCEPTION_MESSAGE = $"Ошибка удаления записи в базе данных экземпляра класса {typeof(DataBaseEntity).ToString()} с Id = {id.Identificator.ToString()} в классе GeneralService";

                ExceptionLogger.LogError(EXCEPTION_MESSAGE);

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
                string EXCEPTION_MESSAGE = $"Ошибка получения записи из базе данных экземпляра класса {typeof(DataBaseEntity).ToString()} с Id = {id.Identificator.ToString()} в классе GeneralService";

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
                string EXCEPTION_MESSAGE = $"Ошибка конвертирования класса {typeof(DataBaseEntity).ToString()} в {typeof(DataTransferObject).ToString()} в классе GeneralService";

                ExceptionLogger.LogError(EXCEPTION_MESSAGE);

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
                string EXCEPTION_MESSAGE = $"Ошибка получения всех записей из базы данных класса {typeof(DataBaseEntity).ToString()} в классе GeneralService";

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
                string EXCEPTION_MESSAGE = $"Ошибка конвертирования класса {typeof(DataBaseEntity).ToString()} в {typeof(DataTransferObject).ToString()} в классе GeneralService";

                ExceptionLogger.LogError(EXCEPTION_MESSAGE);

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
                string EXCEPTION_MESSAGE = $"Ошибка конвертирования класса {typeof(DataTransferObject).ToString()} в {typeof(DataBaseEntity).ToString()} в классе GeneralService";

                ExceptionLogger.LogError(EXCEPTION_MESSAGE);

                throw;
            }


            try
            {
                repository.Update(resultDataBaseEntity);
            }
            catch (Exception)
            {
                string EXCEPTION_MESSAGE = $"Ошибка обновления записи экземпляра класса {typeof(DataBaseEntity).ToString()} в базе данных в классе GeneralService";

                ExceptionLogger.LogError(EXCEPTION_MESSAGE);

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
                string EXCEPTION_MESSAGE = $"Ошибка проверки существования записи экземпляра класса {typeof(DataBaseEntity).ToString()} с Id = {id.Identificator.ToString()} в базе данных в классе GeneralService";

                ExceptionLogger.LogError(EXCEPTION_MESSAGE);

                throw;
            }
        }
    }
}

﻿using BusinessLogicLayer.Interfaces;
using CommonClasses;
using DataAccessLayer.Interfaces;
using ExceptionClasses.Exceptions;
using ExceptionClasses.Logers;
using System;
using System.Collections.Generic;

namespace BusinessLogicLayer.Services
{
    /// <summary>
    /// Класс отвечает за общую реализацию классов, реализующих интерфейс IService
    /// </summary>
    /// <typeparam name="DataTransferObject">Буферный тип, с которым взаимодействует WebAPI</typeparam>
    /// <typeparam name="EntityType">Сущность базы данных</typeparam>
    abstract class GeneralService<DataTransferObject, EntityType> 
        where DataTransferObject : class, IDataTransferObject, new()
        where EntityType: class, new()
    {
        /// <summary>
        /// Предоставляет доступ к данным для сервисов
        /// </summary>
        protected IUnitOfWork _dataBase;

        /// <summary>
        /// Конвертер, для преобразования сущности базы данных в буферный тип и наоборот
        /// </summary>
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
                ExceptionLoger.Log(exception);

                throw;
            }

            try
            {
                repository.Create(entity);
            }
            catch (Exception exception)
            {
                ExceptionLoger.Log(exception);

                throw;
            }
        }

        protected virtual void Delete(uint? id, IRepository<EntityType> repository)
        {
            if (id == null)
            {
                string EXCEPTION_MESSAGE = $"Запрос с клиента на удаление несуществующей записи в базе данных экземпляра класса {typeof(EntityType).ToString()} с Id = null";

                ExceptionLoger.Log(EXCEPTION_MESSAGE, typeof(GeneralService<DataTransferObject, EntityType>).Name, "Delete");

                throw new ClientException();
            }

            IdType idEntity = new IdType
            {
                Identifier = (uint)id
            };

            if ( !Exists(idEntity, repository) )
            {
                string EXCEPTION_MESSAGE = $"Запрос с клиента на удаление несуществующей записи в базе данных экземпляра класса {typeof(EntityType).ToString()} с Id = {idEntity.Identifier.ToString()}";

                ExceptionLoger.Log(EXCEPTION_MESSAGE, typeof(GeneralService<DataTransferObject, EntityType>).Name, "Delete");

                throw new ClientException();
            }

            try
            {
                repository.Delete(idEntity);
            }
            catch (Exception exception)
            {
                ExceptionLoger.Log(exception);

                throw;
            }
        }

        protected virtual DataTransferObject Get(uint? id, IRepository<EntityType> repository)
        {
            if (id == null)
            {
                string EXCEPTION_MESSAGE = $"Запрос с клиента на получение несуществующей записи из базы данных экземпляра класса {typeof(EntityType).ToString()} с Id = null";

                ExceptionLoger.Log(EXCEPTION_MESSAGE, typeof(GeneralService<DataTransferObject, EntityType>).Name, "Get");

                throw new ClientException();
            }

            IdType idEntity = new IdType
            {
                Identifier = (uint)id
            };

            if (!Exists(idEntity, repository))
            {
                string EXCEPTION_MESSAGE = $"Запрос с клиента на получение несуществующей записи из базы данных экземпляра класса {typeof(EntityType).ToString()} с Id = {idEntity.Identifier.ToString()}";

                ExceptionLoger.Log(EXCEPTION_MESSAGE, typeof(GeneralService<DataTransferObject, EntityType>).Name, "Get");

                throw new ClientException();
            }

            EntityType entity = null;
            try
            {
                entity = repository.Get(idEntity);
            }
            catch (Exception exception)
            {
                ExceptionLoger.Log(exception);

                throw;
            }

            try
            {
                DataTransferObject resultEntityDTO = _converter.Convert(entity);

                return resultEntityDTO;
            }
            catch (Exception exception)
            {
                ExceptionLoger.Log(exception);

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
                ExceptionLoger.Log(exception);

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
                ExceptionLoger.Log(exception);

                throw;
            }
        }

        protected virtual void Update(DataTransferObject item, IRepository<EntityType> repository)
        {
            if ( !Exists(item.Id, repository) )
            {
                string EXCEPTION_MESSAGE = $"Запрос с клиента на обновление несуществующей записи в базе данных экземпляра класса {typeof(EntityType).ToString()} с Id = {item.Id.Identifier.ToString()} в классе GeneralService";

                ExceptionLoger.Log(EXCEPTION_MESSAGE, typeof(GeneralService<DataTransferObject, EntityType>).Name, "Update");

                throw new ClientException();
            }

            EntityType resultDataBaseEntity = null;
            try
            {
                resultDataBaseEntity = _converter.Convert(item);
            }
            catch (Exception exception)
            {
                ExceptionLoger.Log(exception);

                throw;
            }

            try
            {
                repository.Update(resultDataBaseEntity);
            }
            catch (Exception exception)
            {
                ExceptionLoger.Log(exception);

                throw;
            }
        }

        private bool Exists(IdType idEntity, IRepository<EntityType> repository)
        {
            try
            {
                return repository.Exists(idEntity);
            }
            catch (Exception exception)
            {
                ExceptionLoger.Log(exception);

                throw;
            }
        }
    }
}

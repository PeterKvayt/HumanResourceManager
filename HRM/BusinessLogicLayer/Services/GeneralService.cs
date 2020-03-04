using CommonClasses;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;

namespace BusinessLogicLayer.Services
{
    abstract class GeneralService<T, TDto> 
        where T: class, new()
        where TDto: new()
    {
        protected IUnitOfWork _dataBase;

        protected virtual void Create(TDto item, IRepository<T> repository)
        {
            T entity = ConvertToEntity(item);

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

        protected virtual void Delete(IdType id, IRepository<T> repository)
        {
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

        protected virtual bool Exists(IdType id, IRepository<T> repository)
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

        protected virtual TDto Get(IdType id, IRepository<T> repository)
        {
            try
            {
                T entity = repository.Get(id);

                TDto resultDTO = ConvertToDTO(entity);

                return resultDTO;
            }
            catch (Exception)
            {
                // ToDo: exception
                throw;
            }
        }

        protected virtual IEnumerable<TDto> GetAll(IRepository<T> repository)
        {
            try
            {
                IEnumerable<T> entityCollection = repository.GetAll();

                List<TDto> resultDtoCollection = new List<TDto> { };

                foreach (var item in entityCollection)
                {
                    TDto dto = ConvertToDTO(item);

                    resultDtoCollection.Add(dto);
                }

                return resultDtoCollection;
            }
            catch (Exception)
            {
                // ToDo: exception
                throw;
            }
        }

        protected virtual void Update(TDto item, IRepository<T> repository)
        {
            T entity = ConvertToEntity(item);

            try
            {
                repository.Update(entity);
            }
            catch (Exception)
            {
                // ToDo: exception
                throw;
            }
        }

        /// <summary>
        /// Сопостовляет TDto c T
        /// </summary>
        /// <param name="item">Экземпляр TDto</param>
        /// <returns>Экземпляр T</returns>
        protected T ConvertToEntity(TDto item)
        {
            T entity = new T
            {
                Id = item.Id,
                Name = item.Name
            };

            return entity;
        }

        /// <summary>
        /// Сопостовляет T c TDto
        /// </summary>
        /// <param name="item">Экземпляр TDto</param>
        /// <returns>Экземпляр T</returns>
        protected TDto ConvertToDTO(T item)
        {
            TDto entityDto = new TDto
            {
                Id = item.Id,
                Name = item.Name
            };

            return entityDto;
        }
    }
}

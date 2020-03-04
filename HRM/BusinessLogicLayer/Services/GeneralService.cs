using CommonClasses;
using DataAccessLayer.Interfaces;
using System;

namespace BusinessLogicLayer.Services
{
    abstract class GeneralService<T, TDto> 
        where T: class, new()
        where TDto: new()
    {
        protected IUnitOfWork _dataBase;

        protected void Delete(IdType id, IRepository<T> repository)
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

        public bool Exists(IdType id, IRepository<T> repository)
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

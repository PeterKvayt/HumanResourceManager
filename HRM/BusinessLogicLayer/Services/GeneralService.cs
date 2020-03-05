using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Mapper;
using CommonClasses;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;

namespace BusinessLogicLayer.Services
{
    abstract class GeneralService<PresentationLayerModel, DataTransferObject, T> 
        where PresentationLayerModel : class, IPresentationLayerModel,  new()
        where DataTransferObject : class, new()
        where T: class, new()
    {
        protected IUnitOfWork _dataBase;

        protected IConverter<DataTransferObject, PresentationLayerModel> _converter;

        protected virtual void Create(PresentationLayerModel item, IRepository<T> repository)
        {
            DataTransferObject dtoEntity = _converter.Convert(item);
            T entity = AutoMapper<T>.Map(dtoEntity);

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

        protected virtual PresentationLayerModel Get(IdType id, IRepository<T> repository)
        {
            try
            {
                T entity = repository.Get(id);

                DataTransferObject entityDTO = AutoMapper<DataTransferObject>.Map(entity);

                PresentationLayerModel resultPLM = _converter.Convert(entityDTO); 

                return resultPLM;
            }
            catch (Exception)
            {
                // ToDo: exception
                throw;
            }
        }

        protected virtual IEnumerable<PresentationLayerModel> GetAll(IRepository<T> repository)
        {
            try
            {
                IEnumerable<T> entityCollection = repository.GetAll();

                List<PresentationLayerModel> resultPlmCollection = new List<PresentationLayerModel> { };

                foreach (var entityItem in entityCollection)
                {
                    DataTransferObject dataTransferObject = AutoMapper<DataTransferObject>.Map(entityItem);
                    PresentationLayerModel presentationLayerModel = _converter.Convert(dataTransferObject);
                    resultPlmCollection.Add(presentationLayerModel);
                }

                return resultPlmCollection;
            }
            catch (Exception)
            {
                // ToDo: exception
                throw;
            }
        }

        protected virtual void Update(PresentationLayerModel item, IRepository<T> repository)
        {
            if ( !Exists(item.Id, repository) )
            {
                // ToDo: exception for user
                throw new Exception();
            }

            DataTransferObject dataTransferObject = _converter.Convert(item);

            T entity = AutoMapper<T>.Map(dataTransferObject);

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

        private bool Exists(IdType id, IRepository<T> repository)
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

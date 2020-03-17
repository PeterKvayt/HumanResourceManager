using BusinessLogicLayer.Interfaces;
using CommonClasses;
using ExceptionClasses.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;

namespace WebAPI.Controllers
{
    abstract public class GeneralController<DataTransferObject> : ControllerBase
    {
        protected virtual IEnumerable<DataTransferObject> GetAll(IService<DataTransferObject> service)
        {
            try
            {
                return service.GetAll();
            }
            catch (Exception)
            {
                throw new HttpListenerException(501);
            }
        }

        protected virtual DataTransferObject Get(uint? id, IService<DataTransferObject> service)
        {
            try
            {
                return service.Get(id);
            }
            catch (ClientException)
            {
                throw new HttpListenerException(404);
            }
            catch (Exception)
            {
                throw new HttpListenerException(501);
            }
        }

        protected virtual void Create(DataTransferObject item, IService<DataTransferObject> service)
        {
            try
            {
                service.Create(item);
            }
            catch (Exception)
            {
                throw new HttpListenerException(501);
            }
        }

        protected virtual void Update(DataTransferObject item, IService<DataTransferObject> service)
        {
            try
            {
                service.Update(item);
            }
            catch (ClientException)
            {
                throw new HttpListenerException(404);
            }
            catch (Exception)
            {
                throw new HttpListenerException(501);
            }
        }

        protected virtual void Delete(uint? id, IService<DataTransferObject> service)
        {
            try
            {
                service.Delete(id);
            }
            catch (ClientException)
            {
                throw new HttpListenerException(404);
            }
            catch (Exception)
            {
                throw new HttpListenerException(501);
            }
        }
    }
}

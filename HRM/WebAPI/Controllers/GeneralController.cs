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
        protected IService<DataTransferObject> _service;

        protected virtual IEnumerable<DataTransferObject> GetAllItems()
        {
            try
            {
                return _service.GetAll();
            }
            catch (Exception)
            {
                throw new HttpListenerException(501);
            }
        }

        protected virtual DataTransferObject GetItem(uint? id)
        {
            try
            {
                return _service.Get(id);
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

        protected virtual void CreateItem(DataTransferObject item)
        {
            try
            {
                _service.Create(item);
            }
            catch (Exception)
            {
                throw new HttpListenerException(501);
            }
        }

        protected virtual void UpdateItem(DataTransferObject item)
        {
            try
            {
                _service.Update(item);
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

        protected virtual void DeleteItem(uint? id)
        {
            try
            {
                _service.Delete(id);
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

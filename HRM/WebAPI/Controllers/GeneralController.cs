using BusinessLogicLayer.Interfaces;
using ExceptionClasses.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;

namespace WebAPI.Controllers
{
    abstract public class GeneralController<DataTransferObject> : ControllerBase where DataTransferObject: class
    {
        protected IService<DataTransferObject> _service;

        private readonly int _notFoundResponse = 404;

        private readonly int _serverErrorResponse = 500;

        protected virtual IEnumerable<DataTransferObject> GetAllItems()
        {
            try
            {
                return _service.GetAll();
            }
            catch (Exception)
            {
                Response.StatusCode = _serverErrorResponse;

                return null;
            }
        }

        protected virtual DataTransferObject GetItem(uint? id)
        {
            try
            {
                Response.StatusCode = _notFoundResponse;


                return _service.Get(id);
            }
            catch (ClientException)
            {
                Response.StatusCode = _notFoundResponse;

                return null;
            }
            catch (Exception)
            {
                Response.StatusCode = _serverErrorResponse;

                return null;
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
                Response.StatusCode = _serverErrorResponse;
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
                Response.StatusCode = _notFoundResponse;
            }
            catch (Exception)
            {
                Response.StatusCode = _serverErrorResponse;
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
                Response.StatusCode = _notFoundResponse;
            }
            catch (Exception)
            {
                Response.StatusCode = _serverErrorResponse;
            }
        }

    }
}

using BusinessLogicLayer.Interfaces;
using ExceptionClasses.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    /// <summary>
    /// Класс отвечает за общую реализацию классов Controller
    /// </summary>
    /// <typeparam name="DataTransferObject">Буферный тип данных</typeparam>
    abstract public class GeneralController<DataTransferObject> : ControllerBase where DataTransferObject: class
    {
        /// <summary>
        /// Сервис, предоставляющий доступ к данным
        /// </summary>
        protected IService<DataTransferObject> _service;

        /// <summary>
        /// Статусный код ошибки поиска несуществующего ресурса
        /// </summary>
        private const int NOT_FOUND_RESPONSE = 404;

        /// <summary>
        /// Статусный код ошибки выполнения операции на сервере
        /// </summary>
        private const int SERVER_ERROR_RESPONSE = 500;

        protected virtual IEnumerable<DataTransferObject> GetAllItems()
        {
            try
            {
                return _service.GetAll();
            }
            catch (Exception)
            {
                Response.StatusCode = SERVER_ERROR_RESPONSE;

                return null;
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
                Response.StatusCode = NOT_FOUND_RESPONSE;

                return null;
            }
            catch (Exception)
            {
                Response.StatusCode = SERVER_ERROR_RESPONSE;

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
                Response.StatusCode = SERVER_ERROR_RESPONSE;
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
                Response.StatusCode = NOT_FOUND_RESPONSE;
            }
            catch (Exception)
            {
                Response.StatusCode = SERVER_ERROR_RESPONSE;
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
                Response.StatusCode = NOT_FOUND_RESPONSE;
            }
            catch (Exception)
            {
                Response.StatusCode = SERVER_ERROR_RESPONSE;
            }
        }
    }
}

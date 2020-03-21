using ExceptionClasses.Loggers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace PresentationLayer.Controllers
{
    /// <summary>
    /// Класс отвечает за общую реализацию классов Controller
    /// </summary>
    /// <typeparam name="EntityModel">Модель сущности</typeparam>
    public abstract class GeneralController<EntityModel> : Controller where EntityModel: class
    {
        /// <summary>
        /// Http-клиент, который выполняет запросы в API
        /// </summary>
        protected HttpClient _client;

        /// <summary>
        /// Код выполнения запроса Http-клиента
        /// </summary>
        protected HttpStatusCode _statusCode;

        /// <summary>
        /// Выполняет GET запрос
        /// </summary>
        /// <param name="apiResource">Название api-ресурса</param>
        /// <returns>Http-ответ</returns>
        private async Task<HttpResponseMessage> GetAsync(string apiResource)
        {
            return await _client.GetAsync(apiResource);
        }

        /// <summary>
        /// Выполняет POST запрос
        /// </summary>
        /// <param name="apiResource">Название api-ресурса</param>
        /// <param name="entity">Передаваемый параметр</param>
        /// <returns>Статусный код выполнения запроса</returns>
        protected async Task<HttpStatusCode> PostAsync(string apiResource, EntityModel entity)
        {
            try
            {
                var response = await _client.PostAsJsonAsync(apiResource, entity);

                return response.StatusCode;
            }
            catch (Exception exception)
            {
                ExceptionLogger.Log(exception);
                
                return HttpStatusCode.NotFound;
            }
            
        }

        /// <summary>
        /// Выполняет PUT запрос
        /// </summary>
        /// <param name="apiResource">Название api-ресурса</param>
        /// <param name="entity">Передаваемый параметр</param>
        /// <returns>Статусный код выполнения запроса</returns>
        protected async Task<HttpStatusCode> PutAsync(string apiResource, EntityModel entity)
        {
            try
            {
                var response = await _client.PutAsJsonAsync(apiResource, entity);

                return response.StatusCode;
            }
            catch (Exception exception)
            {
                ExceptionLogger.Log(exception);

                return HttpStatusCode.NotFound;
            }

        }

        /// <summary>
        /// Выполняет DELETE запрос
        /// </summary>
        /// <param name="apiResource">Название api-ресурса с параметром id</param>
        /// <returns>Статусный код выполнения запроса</returns>
        protected async Task<HttpStatusCode> DeleteAsync(string apiResource)
        {
            try
            {
                var response = await _client.DeleteAsync(apiResource);

                return response.StatusCode;
            }
            catch (Exception exception)
            {
                ExceptionLogger.Log(exception);

                return HttpStatusCode.NotFound;
            }
            
        }

        /// <summary>
        /// Возвращает запрашиваемые данные по конкретной сущности
        /// </summary>
        /// <param name="apiResource">>Название api-ресурса с параметром id</param>
        /// <returns>Кортеж из запрашиваемых данных и статуса выполнения запроса</returns>
        protected async virtual Task<(EntityModel, HttpStatusCode)> GetResultAsync(string apiResource)
        {
            var response = await GetAsync(apiResource);

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var result = await response.Content.ReadAsAsync<EntityModel>();

                    return (result, HttpStatusCode.OK);
                }
                catch (Exception exception)
                {
                    ExceptionLogger.Log(exception);

                    return (null, HttpStatusCode.NotFound);
                }
                
            }
            else
            {
                return (null, response.StatusCode);
            }
        }

        /// <summary>
        /// Возвращает запрашиваемые данные
        /// </summary>
        /// <typeparam name="T">Модель сущности запрашиваемых данных</typeparam>
        /// <param name="apiResource">Название api-ресурса</param>
        /// <returns>Кортеж из запрашиваемых данных и статуса выполнения запроса</returns>
        protected async virtual Task<(List<T>, HttpStatusCode)> GetResultCollectionAsync<T>(string apiResource)
        {
            var response = await GetAsync(apiResource);

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var resultCollection = await response.Content.ReadAsAsync<List<T>>();

                    var result = (resultCollection, HttpStatusCode.OK);

                    return result;
                }
                catch (Exception exception)
                {
                    ExceptionLogger.Log(exception);

                    return (null, HttpStatusCode.NotFound);
                }
                
            }
            else
            {
                return (null, response.StatusCode);
            }
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PresentationLayer.Controllers
{
    public abstract class GeneralController<EntityModel> : Controller where EntityModel: class
    {
        protected HttpClient _client;

        protected HttpStatusCode _statusCode;

        protected void SetClientSettings()
        {
            if (_client.BaseAddress == null)
            {
                _client.BaseAddress = new Uri("http://localhost:65491/api/");
                _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }
        }

        private async Task<HttpResponseMessage> GetAsync(string apiName)
        {
            return await _client.GetAsync(apiName);
        }

        protected async Task<HttpResponseMessage> PostAsync(string apiName, EntityModel entity)
        {
            return await _client.PostAsJsonAsync(apiName, entity);
        }

        protected async Task<HttpResponseMessage> PutAsync(string apiName, EntityModel entity)
        {
            return await _client.PutAsJsonAsync(apiName, entity);
        }

        protected async Task<HttpResponseMessage> DeleteAsync(string apiName)
        {
            return await _client.DeleteAsync(apiName);
        }

        protected async virtual Task<EntityModel> GetResultAsync(string apiName)
        {
            var response = await GetAsync(apiName);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsAsync<EntityModel>();

                return result;
            }
            else
            {
                return null;
            }
        }

        protected async virtual Task<(List<CommonEntityModel>, HttpStatusCode)> GetResultCollectionAsync<CommonEntityModel>(string apiName)
        {
            var response = await GetAsync(apiName);

            if (response.IsSuccessStatusCode)
            {
                var resultCollection = await response.Content.ReadAsAsync<List<CommonEntityModel>>();

                var result = (resultCollection, HttpStatusCode.OK);

                return result;
            }
            else
            {
                return (null, response.StatusCode);
            }
        }
    }
}

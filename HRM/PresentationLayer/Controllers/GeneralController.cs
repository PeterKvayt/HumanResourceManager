﻿using Microsoft.AspNetCore.Mvc;
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

        protected async Task<HttpStatusCode> PostAsync(string apiName, EntityModel entity)
        {
            var response = await _client.PostAsJsonAsync(apiName, entity);

            return response.StatusCode;
        }

        protected async Task<HttpStatusCode> PutAsync(string apiName, EntityModel entity)
        {
            var response = await _client.PutAsJsonAsync(apiName, entity);

            return response.StatusCode;
        }

        protected async Task<HttpStatusCode> DeleteAsync(string apiName)
        {
            var response = await _client.DeleteAsync(apiName);

            return response.StatusCode;
        }

        protected async virtual Task<(EntityModel, HttpStatusCode)> GetResultAsync(string apiName)
        {
            var response = await GetAsync(apiName);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsAsync<EntityModel>();

                return (result, HttpStatusCode.OK);
            }
            else
            {
                return (null, response.StatusCode);
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

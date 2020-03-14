using BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.Interfaces;
using CommonClasses;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Models;
using PresentationLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PresentationLayer.Controllers
{
    public class ActivityTypesController : Controller
    {
        private readonly HttpClient _client;

        private const string METHOD_NAME = "ActivityTypes";

        public ActivityTypesController(HttpClient client)
        {
            _client = client;

            if (_client.BaseAddress == null)
            {
                _client.BaseAddress = new Uri("http://localhost:65491/api/");
                _client.DefaultRequestHeaders.Accept.Clear();
                _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<ActivityTypeModel> responseActivityTypeCollection = new List<ActivityTypeModel> { };
            HttpResponseMessage responseMessage = await _client.GetAsync(METHOD_NAME);

            if (responseMessage.IsSuccessStatusCode)
            {
                responseActivityTypeCollection = await responseMessage.Content.ReadAsAsync<List<ActivityTypeModel>>();
            }

            ActivityTypeViewModel model = new ActivityTypeViewModel
            {
                ActivityTypeCollection = responseActivityTypeCollection
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ActivityTypeViewModel model)
        {
            ActivityTypeModel activityType
 = model.ActivityType;

            HttpResponseMessage responseMessage = await _client.PostAsJsonAsync(METHOD_NAME, activityType);

            if (responseMessage.IsSuccessStatusCode)
            {
                return Redirect("/" + METHOD_NAME + "/Index");
            }

            return Redirect("/" + METHOD_NAME + "/Create");
        }

        [HttpGet]
        public async Task<IActionResult> Update(uint id)
        {
            HttpResponseMessage responseMessage = await _client.GetAsync(METHOD_NAME + "/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                ActivityTypeModel activityType = await responseMessage.Content.ReadAsAsync<ActivityTypeModel>();

                ActivityTypeViewModel model = new ActivityTypeViewModel
                {
                    ActivityType = activityType
                };

                return View(model);
            }

            return Redirect("/" + METHOD_NAME + "/Index");
        }

        [HttpPost]
        public async Task<IActionResult> Update(ActivityTypeViewModel model)
        {
            ActivityTypeModel activityType = model.ActivityType;

            HttpResponseMessage responseMessage = await _client.PutAsJsonAsync(METHOD_NAME, activityType);
            if (responseMessage.IsSuccessStatusCode)
            {
                return Redirect("/" + METHOD_NAME + "/Index");
            }

            return Redirect("/" + METHOD_NAME + "/Update/" + activityType.Id.Identificator);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(uint id)
        {
            HttpResponseMessage responseMessage = await _client.DeleteAsync(METHOD_NAME + "/" + id);

            return Redirect("/" + METHOD_NAME + "/Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

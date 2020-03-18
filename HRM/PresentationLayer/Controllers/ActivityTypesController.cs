using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Models;
using PresentationLayer.ViewModels;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace PresentationLayer.Controllers
{
    public class ActivityTypesController : GeneralController<ActivityTypeModel>
    {
        private const string ACTIVITY_TYPES_API = "ActivityTypes";

        public ActivityTypesController(HttpClient client)
        {
            _client = client;

            SetClientSettings();
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var (responseActivityTypeCollection, statusCode) = await GetResultCollectionAsync<ActivityTypeModel>(ACTIVITY_TYPES_API);

            if (responseActivityTypeCollection != null)
            {
                ActivityTypeViewModel model = new ActivityTypeViewModel
                {
                    ActivityTypeCollection = responseActivityTypeCollection
                };

                return View(model);
            }
            else
            {
                return RedirectToAction("Error", ACTIVITY_TYPES_API, new { code = statusCode });
            }

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ActivityTypeViewModel model)
        {
            ActivityTypeModel activityType = model.ActivityTypeModel;

            var responseMessage = await PostAsync(ACTIVITY_TYPES_API, activityType);
            if (responseMessage.IsSuccessStatusCode)
            {
                return Redirect("/" + ACTIVITY_TYPES_API + "/Index");
            }

            return Redirect("/" + ACTIVITY_TYPES_API + "/Create");
        }

        [HttpGet]
        public async Task<IActionResult> Update(uint? id)
        {
            //if (id == null)
            //{
            //    return Redirect("/" + ACTIVITY_TYPES_API + "/Error");
            //}

            var activityType = await GetResultAsync(ACTIVITY_TYPES_API + "/" + id);
            if (activityType != null)
            {
                ActivityTypeViewModel model = new ActivityTypeViewModel
                {
                    ActivityTypeModel = activityType
                };

                return View(model);
            }
            else
            {
                // ToDo: exception

                return Redirect("/" + ACTIVITY_TYPES_API + "/Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(ActivityTypeViewModel model)
        {
            ActivityTypeModel activityType = model.ActivityTypeModel;

            var responseMessage = await PutAsync(ACTIVITY_TYPES_API, activityType);
            if (responseMessage.IsSuccessStatusCode)
            {
                return Redirect("/" + ACTIVITY_TYPES_API + "/Index");
            }

            return Redirect("/" + ACTIVITY_TYPES_API + "/Update/" + activityType.Id.Identificator);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(uint? id)
        {
            if (id == null)
            {
                return Redirect("/" + ACTIVITY_TYPES_API + "/Error");
            }

            await DeleteAsync(ACTIVITY_TYPES_API + "/" + id);

            return Redirect("/" + ACTIVITY_TYPES_API + "/Error");
        }

        [HttpGet]
        public IActionResult Error(HttpStatusCode code)
        {
            ErrorViewModel model = new ErrorViewModel
            {
                StausCode = code
            };

            return View(model);
        }
    }
}

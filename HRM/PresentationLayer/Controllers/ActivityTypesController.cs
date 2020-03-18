using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Models;
using PresentationLayer.ViewModels;
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
                return RedirectToAction("Error", new { code = statusCode });
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

            var statusCode = await PostAsync(ACTIVITY_TYPES_API, activityType);

            if (statusCode == HttpStatusCode.OK)
            {
                return Redirect("/" + ACTIVITY_TYPES_API);
            }
            else
            {
                return RedirectToAction("Error", new { code = statusCode });
            }
        }

        [HttpGet]
        public async Task<IActionResult> Update(uint? id)
        {
            var (activityType, statusCode) = await GetResultAsync(ACTIVITY_TYPES_API + "/" + id);

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
                return RedirectToAction("Error", new { code = statusCode });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(ActivityTypeViewModel model)
        {
            ActivityTypeModel activityType = model.ActivityTypeModel;

            var statusCode = await PutAsync(ACTIVITY_TYPES_API, activityType);

            if (statusCode == HttpStatusCode.OK)
            {
                return Redirect("/" + ACTIVITY_TYPES_API);
            }
            else
            {
                return RedirectToAction("Error", new { code = statusCode });
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(uint? id)
        {
            var statusCode = await DeleteAsync(ACTIVITY_TYPES_API + "/" + id);

            if (statusCode == HttpStatusCode.OK)
            {
                return Redirect("/" + ACTIVITY_TYPES_API);
            }
            else
            {
                return RedirectToAction("Error", new { code = statusCode });
            }
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

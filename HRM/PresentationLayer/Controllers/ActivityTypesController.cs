using BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.Interfaces;
using CommonClasses;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Models;
using PresentationLayer.ViewModels;
using System.Collections.Generic;
using System.Diagnostics;

namespace PresentationLayer.Controllers
{
    public class ActivityTypesController : Controller
    {
        private readonly IService<ActivityTypeDTO> _service;

        public ActivityTypesController(IServiceUnitOfWork service)
        {
            _service = service.AcivityTypeService;
        }

        public IActionResult Index()
        {
            IEnumerable<ActivityTypeDTO> activityTypeDtoCollection = _service.GetAll();

            List<ActivityTypeModel> activityTypeModelCollection = new List<ActivityTypeModel> { };
            foreach (var item in activityTypeDtoCollection)
            {
                var activityType = AutoMapper<ActivityTypeModel>.Map(item);
                activityTypeModelCollection.Add(activityType);
            }

            ActivityTypeViewModel model = new ActivityTypeViewModel(activityTypeModelCollection);

            return View(model);
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

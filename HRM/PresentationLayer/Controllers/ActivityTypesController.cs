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

        [HttpGet("ActivityTypes/")]
        public IActionResult Index()
        {
            IEnumerable<ActivityTypeDTO> activityTypeDtoCollection = _service.GetAll();

            List<ActivityTypeModel> activityTypeModelCollection = new List<ActivityTypeModel> { };
            foreach (var item in activityTypeDtoCollection)
            {
                var activityType = AutoMapper<ActivityTypeModel>.Map(item);
                activityTypeModelCollection.Add(activityType);
            }

            ActivityTypeViewModel model = new ActivityTypeViewModel
            {
                ActivityTypeCollection = activityTypeModelCollection
            };

            return View(model);
        }

        [HttpDelete("ActivityTypes/{id}")]
        public IActionResult Index(uint id)
        {
            IdType idType = new IdType
            {
                Identificator = id
            };
            _service.Delete(idType);

            return Index();
        }

        [HttpPost("ActivityTypes/")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("ActivityTypes/{newModel}")]
        public IActionResult Create(ActivityTypeModel newModel)
        {
            ActivityTypeDTO activityTypeDTO = AutoMapper<ActivityTypeDTO>.Map(newModel);

            _service.Create(activityTypeDTO);

            //return Redirect("/ActivityTypes");
            return Index();
        }

        [HttpGet("ActivityTypes/{id}")]
        public IActionResult Update(uint id)
        {
            IdType idType = new IdType
            {
                Identificator = id
            };
            ActivityTypeDTO activityTypeDTO = _service.Get(idType);

            ActivityTypeModel activityTypeModel = AutoMapper<ActivityTypeModel>.Map(activityTypeDTO);

            ActivityTypeViewModel activityTypeViewModel = new ActivityTypeViewModel
            {
                ActivityType = activityTypeModel
            };
            //ActivityTypeViewModel model = new ActivityTypeViewModel
            //{
            //    ActivityType = activityTypeModel
            //};

            return View(activityTypeViewModel);
        }

        [HttpPut("ActivityTypes/{model}")]
        public IActionResult Update([FromBody]ActivityTypeViewModel model)
        {
            ActivityTypeModel activityTypeModel = model.ActivityType;

            ActivityTypeDTO activityTypeDTO = AutoMapper<ActivityTypeDTO>.Map(activityTypeModel);

            _service.Update(activityTypeDTO);

            return Redirect("/ActivityTypes");
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

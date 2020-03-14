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

namespace PresentationLayer.Controllers
{
    public class ActivityTypesController : Controller
    {
        private readonly HttpClient _client;

        public ActivityTypesController(HttpClient client)
        {
            _client = client;
            _client.BaseAddress = new Uri("http://localhost:65491");
        }

        //[HttpGet("ActivityTypes/")]
        //public IActionResult Index()
        //{
        //    IEnumerable<ActivityTypeDTO> activityTypeDtoCollection = _client.GetAll();

        //    List<ActivityTypeModel> activityTypeModelCollection = new List<ActivityTypeModel> { };
        //    foreach (var item in activityTypeDtoCollection)
        //    {
        //        var activityType = AutoMapper<ActivityTypeModel>.Map(item);
        //        activityTypeModelCollection.Add(activityType);
        //    }

        //    ActivityTypeViewModel model = new ActivityTypeViewModel
        //    {
        //        ActivityTypeCollection = activityTypeModelCollection
        //    };

        //    return View(model);
        //}

        //[HttpDelete("ActivityTypes/{id}")]
        //public IActionResult Index(uint id)
        //{
        //    IdType idType = new IdType
        //    {
        //        Identificator = id
        //    };
        //    _client.Delete(idType);

        //    return Index();
        //}

        //[HttpPost("ActivityTypes/")]
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost("ActivityTypes/{newModel}")]
        //public IActionResult Create(ActivityTypeModel newModel)
        //{
        //    ActivityTypeDTO activityTypeDTO = AutoMapper<ActivityTypeDTO>.Map(newModel);

        //    _client.Create(activityTypeDTO);

        //    //return Redirect("/ActivityTypes");
        //    return Index();
        //}

        //[HttpGet("ActivityTypes/{id}")]
        //public IActionResult Update(uint id)
        //{
        //    IdType idType = new IdType
        //    {
        //        Identificator = id
        //    };
        //    ActivityTypeDTO activityTypeDTO = _client.Get(idType);

        //    ActivityTypeModel activityTypeModel = AutoMapper<ActivityTypeModel>.Map(activityTypeDTO);

        //    ActivityTypeViewModel activityTypeViewModel = new ActivityTypeViewModel
        //    {
        //        ActivityType = activityTypeModel
        //    };
        //    //ActivityTypeViewModel model = new ActivityTypeViewModel
        //    //{
        //    //    ActivityType = activityTypeModel
        //    //};

        //    return View(activityTypeViewModel);
        //}

        //[HttpPut("ActivityTypes/{model}")]
        //public IActionResult Update([FromBody]ActivityTypeViewModel model)
        //{
        //    ActivityTypeModel activityTypeModel = model.ActivityType;

        //    ActivityTypeDTO activityTypeDTO = AutoMapper<ActivityTypeDTO>.Map(activityTypeModel);

        //    _client.Update(activityTypeDTO);

        //    return Redirect("/ActivityTypes");
        //}

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

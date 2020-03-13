using BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.Interfaces;
using CommonClasses;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationLayer.Controllers
{
    [Route("/[controller]")]
    public class PositionsController : Controller
    {
        private readonly IService<PositionDTO> _service;

        public PositionsController(IServiceUnitOfWork service)
        {
            _service = service.PositionService;
        }

        [HttpGet]
        public IEnumerable<PositionModel> Index()
        {
            IEnumerable<PositionDTO> positionDTOs = _service.GetAll();

            var postionResultCollection = new List<PositionModel> { };
            foreach (var positionDTO in positionDTOs)
            {
                var positionModel = AutoMapper<PositionModel>.Map(positionDTO);
                postionResultCollection.Add(positionModel);
            }

            return postionResultCollection;
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

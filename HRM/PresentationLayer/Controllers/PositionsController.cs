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
    [Route("/[controller]")]
    public class PositionsController : Controller
    {
        private readonly HttpClient _client;

        public PositionsController(HttpClient client)
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
            List<PositionModel> responsePositionCollection = new List<PositionModel> { };
            HttpResponseMessage responseMessage = await _client.GetAsync("Positions");

            bool successResponse = responseMessage.IsSuccessStatusCode;

            if (successResponse)
            {
                responsePositionCollection = await responseMessage.Content.ReadAsAsync<List<PositionModel>>();
            }

            PositionViewModel model = new PositionViewModel
            {
                PositionCollection = responsePositionCollection
            };

            return View(model);
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(PositionViewModel model)
        {
            PositionModel position = model.Position;

            HttpResponseMessage responseMessage = await _client.PostAsJsonAsync("Create", position);

            bool resp = responseMessage.IsSuccessStatusCode;

            if (resp)
            {
                return Redirect("Index");
            }

            return Redirect("Create");
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

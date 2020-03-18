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
    public class PositionsController : GeneralController<PositionModel>
    {
        private const string POSITIONS_API = "Positions";

        public PositionsController(HttpClient client)
        {
            _client = client;

            SetClientSettings();
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var (responsePositionCollection, statusCode) = await GetResultCollectionAsync<PositionModel>(POSITIONS_API);
            if (responsePositionCollection != null)
            {
                PositionViewModel model = new PositionViewModel
                {
                    PositionCollection = responsePositionCollection
                };

                return View(model);
            }
            else
            {
                // ToDo: exception

                return Redirect("/" + POSITIONS_API + "/Error");
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PositionViewModel model)
        {
            PositionModel position = model.PositionModel;

            var responseMessage = await PostAsync(POSITIONS_API, position);
            if (responseMessage.IsSuccessStatusCode)
            {
                return Redirect("/" + POSITIONS_API + "/Index");
            }

            return Redirect("/" + POSITIONS_API + "/Create");
        }

        [HttpGet]
        public async Task<IActionResult> Update(uint? id)
        {
            var (position, statusCode) = await GetResultAsync(POSITIONS_API + "/" + id);
            if (position != null)
            {
                PositionViewModel model = new PositionViewModel
                {
                   PositionModel  = position
                };

                return View(model);
            }
            else
            {
                return RedirectToAction("Error", POSITIONS_API, new { code = statusCode });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(PositionViewModel model)
        {
            PositionModel position = model.PositionModel;

            var responseMessage = await PutAsync(POSITIONS_API, position);
            if (responseMessage.IsSuccessStatusCode)
            {
                return Redirect("/" + POSITIONS_API + "/Index");
            }

            return Redirect("/" + POSITIONS_API + "/Update/" + position.Id.Identificator);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(uint? id)
        {
            await DeleteAsync(POSITIONS_API + "/" + id);

            return Redirect("/" + POSITIONS_API + "/Index");
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

using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Models;
using PresentationLayer.ViewModels;
using System.Collections.Generic;
using System.Diagnostics;
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
            List<PositionModel> responsePositionCollection = await GetResultCollectionAsync<PositionModel>(POSITIONS_API);
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
        public async Task<IActionResult> Update(uint id)
        {
            var position = await GetResultAsync(POSITIONS_API + "/" + id);
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
                // ToDo: exception

                return Redirect("/" + POSITIONS_API + "/Error");
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
        public async Task<IActionResult> Delete(uint id)
        {
            await DeleteAsync(POSITIONS_API + "/" + id);

            return Redirect("/" + POSITIONS_API + "/Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

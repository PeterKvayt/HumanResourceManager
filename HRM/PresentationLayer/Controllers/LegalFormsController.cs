using BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Models;
using PresentationLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PresentationLayer.Controllers
{
    public class LegalFormsController : Controller
    {
        private HttpClient _client;

        private const string METHOD_NAME = "LegalForms";

        public LegalFormsController(HttpClient client)
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
            List<LegalFormModel> responseLegalFormCollection = new List<LegalFormModel> { };
            HttpResponseMessage responseMessage = await _client.GetAsync(METHOD_NAME);

            if (responseMessage.IsSuccessStatusCode)
            {
                responseLegalFormCollection = await responseMessage.Content.ReadAsAsync<List<LegalFormModel>>();
            }

            LegalFormViewModel model = new LegalFormViewModel
            {
                LegalFormModelCollection = responseLegalFormCollection
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(LegalFormViewModel model)
        {
            LegalFormModel legalForm = model.LegalFormModel;

            HttpResponseMessage responseMessage = await _client.PostAsJsonAsync(METHOD_NAME, legalForm);

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
                LegalFormModel legalForm = await responseMessage.Content.ReadAsAsync<LegalFormModel>();

                LegalFormViewModel model = new LegalFormViewModel
                {
                    LegalFormModel = legalForm
                };

                return View(model);
            }

            return Redirect("/" + METHOD_NAME + "/Index");
        }

        [HttpPost]
        public async Task<IActionResult> Update(LegalFormViewModel model)
        {
            LegalFormModel position = model.LegalFormModel;

            HttpResponseMessage responseMessage = await _client.PutAsJsonAsync(METHOD_NAME, position);
            if (responseMessage.IsSuccessStatusCode)
            {
                return Redirect("/" + METHOD_NAME + "/Index");
            }

            return Redirect("/" + METHOD_NAME + "/Update/" + position.Id.Identificator);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(uint id)
        {
            HttpResponseMessage responseMessage = await _client.DeleteAsync(METHOD_NAME + "/" + id);

            return Redirect("/" + METHOD_NAME + "/Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Models;
using PresentationLayer.ViewModels;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace PresentationLayer.Controllers
{
    public class LegalFormsController : GeneralController<LegalFormModel>
    {
        private const string LEGAL_FORMS_API = "LegalForms";

        public LegalFormsController(HttpClient client)
        {
            _client = client;

            SetClientSettings();
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var (responseLegalFormCollection, statusCode) = await GetResultCollectionAsync<LegalFormModel>(LEGAL_FORMS_API);

            if (responseLegalFormCollection != null)
            {
                LegalFormViewModel model = new LegalFormViewModel
                {
                    LegalFormCollection = responseLegalFormCollection
                };

                return View(model);
            }
            else
            {
                // ToDo: exception

                return Redirect("/" + LEGAL_FORMS_API + "/Error");
            }

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

            var responseMessage = await PostAsync(LEGAL_FORMS_API, legalForm);
            if (responseMessage.IsSuccessStatusCode)
            {
                return Redirect("/" + LEGAL_FORMS_API + "/Index");
            }

            return Redirect("/" + LEGAL_FORMS_API + "/Create");
        }

        [HttpGet]
        public async Task<IActionResult> Update(uint id)
        {
            var legalForm = await GetResultAsync(LEGAL_FORMS_API + "/" + id);
            if (legalForm != null)
            {
                LegalFormViewModel model = new LegalFormViewModel
                {
                    LegalFormModel = legalForm
                };

                return View(model);
            }
            else
            {
                // ToDo: exception

                return Redirect("/" + LEGAL_FORMS_API + "/Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(LegalFormViewModel model)
        {
            LegalFormModel position = model.LegalFormModel;

            var responseMessage = await PutAsync(LEGAL_FORMS_API, position);
            if (responseMessage.IsSuccessStatusCode)
            {
                return Redirect("/" + LEGAL_FORMS_API + "/Index");
            }

            return Redirect("/" + LEGAL_FORMS_API + "/Update/" + position.Id.Identificator);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(uint id)
        {
            await DeleteAsync(LEGAL_FORMS_API + "/" + id);

            return Redirect("/" + LEGAL_FORMS_API + "/Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel());
        }
    }
}

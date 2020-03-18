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

            var statusCode = await PostAsync(LEGAL_FORMS_API, legalForm);

            if (statusCode == HttpStatusCode.OK)
            {
                return Redirect("/" + LEGAL_FORMS_API);
            }
            else
            {
                return RedirectToAction("Error", new { code = statusCode });
            }
        }

        [HttpGet]
        public async Task<IActionResult> Update(uint? id)
        {
            var (legalForm, statusCode) = await GetResultAsync(LEGAL_FORMS_API + "/" + id);
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
                return RedirectToAction("Error", new { code = statusCode });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(LegalFormViewModel model)
        {
            LegalFormModel position = model.LegalFormModel;

            var statusCode = await PutAsync(LEGAL_FORMS_API, position);

            if (statusCode == HttpStatusCode.OK)
            {
                return Redirect("/" + LEGAL_FORMS_API);
            }
            else
            {
                return RedirectToAction("Error", new { code = statusCode });
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(uint? id)
        {
            var statusCode = await DeleteAsync(LEGAL_FORMS_API + "/" + id);

            if (statusCode == HttpStatusCode.OK)
            {
                return Redirect("/" + LEGAL_FORMS_API + "/");
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

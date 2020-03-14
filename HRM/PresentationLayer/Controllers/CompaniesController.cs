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
    public class CompaniesController : Controller
    {
        private HttpClient _client;

        private const string COMPANIES_API = "Companies";

        private const string ACTIVITY_TYPES_API = "ActivityTypes";

        private const string LEGAL_FORMS_API = "LegalForms";

        public CompaniesController(HttpClient client)
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
            List<CompanyModel> responseCompanyCollection = new List<CompanyModel> { };

            HttpResponseMessage responseMessage = await _client.GetAsync(COMPANIES_API);
            if (responseMessage.IsSuccessStatusCode)
            {
                responseCompanyCollection = await responseMessage.Content.ReadAsAsync<List<CompanyModel>>();
            }

            CompanyViewModel model = new CompanyViewModel
            {
                CompanyModelCollection = responseCompanyCollection
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            List<ActivityTypeModel> responseActivityTypeCollection = new List<ActivityTypeModel> { };

            HttpResponseMessage responseMessage = await _client.GetAsync(ACTIVITY_TYPES_API);
            if (responseMessage.IsSuccessStatusCode)
            {
                responseActivityTypeCollection = await responseMessage.Content.ReadAsAsync<List<ActivityTypeModel>>();
            }

            List<LegalFormModel> responseLegalFormCollection = new List<LegalFormModel> { };

            responseMessage = await _client.GetAsync(LEGAL_FORMS_API);
            if (responseMessage.IsSuccessStatusCode)
            {
                responseLegalFormCollection = await responseMessage.Content.ReadAsAsync<List<LegalFormModel>>();
            }

            CompanyViewModel model = new CompanyViewModel
            {
                LegalFormCollection = responseLegalFormCollection,
                ActivityTypeCollection = responseActivityTypeCollection
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CompanyViewModel model)
        {
            CompanyModel company = model.CompanyModel;

            HttpResponseMessage responseMessage = await _client.PostAsJsonAsync(COMPANIES_API, company);

            if (responseMessage.IsSuccessStatusCode)
            {
                return Redirect("/" + COMPANIES_API + "/Index");
            }

            return Redirect("/" + COMPANIES_API + "/Create");
        }

        [HttpGet]
        public async Task<IActionResult> Update(uint id)
        {
            HttpResponseMessage responseMessage = await _client.GetAsync(COMPANIES_API + "/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                CompanyViewModel model = new CompanyViewModel
                {
                    CompanyModel = await responseMessage.Content.ReadAsAsync<CompanyModel>()
                };

                List<ActivityTypeModel> responseActivityTypeCollection = new List<ActivityTypeModel> { };

                responseMessage = await _client.GetAsync(ACTIVITY_TYPES_API);
                if (responseMessage.IsSuccessStatusCode)
                {
                    responseActivityTypeCollection = await responseMessage.Content.ReadAsAsync<List<ActivityTypeModel>>();
                }

                List<LegalFormModel> responseLegalFormCollection = new List<LegalFormModel> { };

                responseMessage = await _client.GetAsync(LEGAL_FORMS_API);
                if (responseMessage.IsSuccessStatusCode)
                {
                    responseLegalFormCollection = await responseMessage.Content.ReadAsAsync<List<LegalFormModel>>();
                }

                model.LegalFormCollection = responseLegalFormCollection;
                model.ActivityTypeCollection = responseActivityTypeCollection;

                return View(model);
            }       

            return Redirect("/" + COMPANIES_API + "/Index");
        }

        [HttpPost]
        public async Task<IActionResult> Update(CompanyViewModel model)
        {
            CompanyModel companyModel = model.CompanyModel;

            HttpResponseMessage responseMessage = await _client.PutAsJsonAsync(COMPANIES_API, companyModel);
            if (responseMessage.IsSuccessStatusCode)
            {
                return Redirect("/" + COMPANIES_API + "/Index");
            }

            return Redirect("/" + COMPANIES_API + "/Update/" + companyModel.Id.Identificator);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(uint id)
        {
            HttpResponseMessage responseMessage = await _client.DeleteAsync(COMPANIES_API + "/" + id);

            return Redirect("/" + COMPANIES_API + "/Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

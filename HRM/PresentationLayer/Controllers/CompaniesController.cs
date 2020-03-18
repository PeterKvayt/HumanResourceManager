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
    public class CompaniesController : GeneralController<CompanyModel>
    {
        private const string COMPANIES_API = "Companies";

        private const string ACTIVITY_TYPES_API = "ActivityTypes";

        private const string LEGAL_FORMS_API = "LegalForms";

        public CompaniesController(HttpClient client)
        {
            _client = client;

            SetClientSettings();
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var (responseCompanyCollection, statusCode) = await GetResultCollectionAsync<CompanyModel>(COMPANIES_API);

            if (responseCompanyCollection != null)
            {
                CompanyViewModel model = new CompanyViewModel
                {
                    CompanyCollection = responseCompanyCollection
                };

                return View(model);
            }
            else
            {
                // ToDo: exception

                return Redirect("/" + COMPANIES_API + "/Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var (model, statusCode) = await GetViewModelWithCollectionsAsync();

            if (model != null)
            {
                return View(model);
            }
            else
            {
                //ToDo: exception

                return Redirect("/" + COMPANIES_API + "/Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(CompanyViewModel model)
        {
            CompanyModel company = model.CompanyModel;

            var responseMessage = await PostAsync(COMPANIES_API, company);
            if (responseMessage.IsSuccessStatusCode)
            {
                return Redirect("/" + COMPANIES_API + "/Index");
            }

            return Redirect("/" + COMPANIES_API + "/Create");
        }

        [HttpGet]
        public async Task<IActionResult> Update(uint id)
        {
            CompanyModel companyModel = await GetResultAsync(COMPANIES_API + "/" + id);
            if (companyModel != null)
            {
                var (model, statusCode) = await GetViewModelWithCollectionsAsync();
                if (model != null)
                {
                    model.CompanyModel = companyModel;

                    return View(model);
                }
                else
                {
                    // ToDo: exception

                    return Redirect("/" + COMPANIES_API + "/Error");
                }
            }
            else
            {
                // ToDo: exception

                return Redirect("/" + COMPANIES_API + "/Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(CompanyViewModel model)
        {
            CompanyModel companyModel = model.CompanyModel;

            var responseMessage = await PutAsync(COMPANIES_API, companyModel);
            if (responseMessage.IsSuccessStatusCode)
            {
                return Redirect("/" + COMPANIES_API + "/Index");
            }

            return Redirect("/" + COMPANIES_API + "/Update/" + companyModel.Id.Identificator);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(uint id)
        {
            await DeleteAsync(COMPANIES_API + "/" + id);

            return Redirect("/" + COMPANIES_API + "/Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel());
        }

        private async Task<(CompanyViewModel, HttpStatusCode)> GetViewModelWithCollectionsAsync()
        {
            var activityTypeResponse  = await GetResultCollectionAsync<ActivityTypeModel>(ACTIVITY_TYPES_API);

            var legalFormResponse = await GetResultCollectionAsync<LegalFormModel>(LEGAL_FORMS_API);

            if (legalFormResponse.Item1 != null && activityTypeResponse.Item1 != null)
            {
                CompanyViewModel model = new CompanyViewModel
                {
                    LegalFormCollection = legalFormResponse.Item1,
                    ActivityTypeCollection = activityTypeResponse.Item1
                };

                return (model, HttpStatusCode.OK);
            }
            else
            {
                var notFoundStatus = HttpStatusCode.NotFound;

                if (legalFormResponse.Item2 == notFoundStatus && activityTypeResponse.Item2 == notFoundStatus)
                {
                    return (null, notFoundStatus);
                }
                else
                {
                    return (null, HttpStatusCode.InternalServerError);
                }
            }
        }
    }
}

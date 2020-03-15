using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Models;
using PresentationLayer.ViewModels;
using System.Collections.Generic;
using System.Diagnostics;
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
            List<CompanyModel> responseCompanyCollection = await GetResultCollectionAsync<CompanyModel>(COMPANIES_API);

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
            List<ActivityTypeModel> responseActivityTypeCollection = await GetResultCollectionAsync<ActivityTypeModel>(ACTIVITY_TYPES_API);

            List<LegalFormModel> responseLegalFormCollection = await GetResultCollectionAsync<LegalFormModel>(LEGAL_FORMS_API);

            if (responseActivityTypeCollection != null && responseLegalFormCollection != null)
            {
                CompanyViewModel model = new CompanyViewModel
                {
                    LegalFormCollection = responseLegalFormCollection,
                    ActivityTypeCollection = responseActivityTypeCollection
                };

                return View(model);
            }
            else
            {
                // ToDo: exception

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
                List<ActivityTypeModel> responseActivityTypeCollection = await GetResultCollectionAsync<ActivityTypeModel>(ACTIVITY_TYPES_API);

                List<LegalFormModel> responseLegalFormCollection = await GetResultCollectionAsync<LegalFormModel>(LEGAL_FORMS_API);

                if (responseActivityTypeCollection != null && responseLegalFormCollection != null)
                {
                    CompanyViewModel model = new CompanyViewModel
                    {
                        CompanyModel = companyModel,
                        LegalFormCollection = responseLegalFormCollection,
                        ActivityTypeCollection = responseActivityTypeCollection
                    };

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
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

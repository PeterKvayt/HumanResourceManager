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
    public class EmployeesController : GeneralController<EmployeeModel>
    {
        private const string EMPLOYEES_API = "Employees";

        private const string COMPANIES_API = "Companies";

        private const string POSITIONS_API = "Positions";

        public EmployeesController(HttpClient client)
        {
            _client = client;

            SetClientSettings();
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<EmployeeModel> responseEmployeeCollection = await GetResultCollectionAsync<EmployeeModel>(EMPLOYEES_API);

            if (responseEmployeeCollection != null)
            {
                EmployeeViewModel model = new EmployeeViewModel
                {
                    EmployeeCollection = responseEmployeeCollection
                };

                return View(model);
            }
            else
            {
                // ToDo: exception

                return Redirect("/" + EMPLOYEES_API + "/Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = await GetViewModelWithCollectionsAsync();
            if (model != null)
            {
                return View(model);
            }
            else
            {
                // ToDo: exception

                return Redirect("/" + EMPLOYEES_API + "/Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeViewModel model)
        {
            EmployeeModel employee = model.EmployeeModel;

            var responseMessage = await PostAsync(EMPLOYEES_API, employee);
            if (responseMessage.IsSuccessStatusCode)
            {
                return Redirect("/" + EMPLOYEES_API + "/Index");
            }

            return Redirect("/" + EMPLOYEES_API + "/Create");
        }

        [HttpGet]
        public async Task<IActionResult> Update(uint id)
        {
            EmployeeModel employeeModel = await GetResultAsync(EMPLOYEES_API + "/" + id);
            if (employeeModel != null)
            {
                var model = await GetViewModelWithCollectionsAsync();
                if (model != null)
                {
                    model.EmployeeModel = employeeModel;

                    return View(model);
                }
                else
                {
                    // ToDo: exception

                    return Redirect("/" + EMPLOYEES_API + "/Error");
                }
            }
            else
            {
                // ToDo: exception

                return Redirect("/" + EMPLOYEES_API + "/Error");
            }


            //HttpResponseMessage responseMessage = await _client.GetAsync(EMPLOYEES_API + "/" + id);
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    EmployeeViewModel model = new EmployeeViewModel
            //    {
            //        EmployeeModel = await responseMessage.Content.ReadAsAsync<EmployeeModel>()
            //    };

            //    List<CompanyModel> responseCompanyCollection = new List<CompanyModel> { };

            //    responseMessage = await _client.GetAsync(COMPANIES_API);
            //    if (responseMessage.IsSuccessStatusCode)
            //    {
            //        responseCompanyCollection = await responseMessage.Content.ReadAsAsync<List<CompanyModel>>();
            //    }

            //    List<PositionModel> responsePositionCollection = new List<PositionModel> { };

            //    responseMessage = await _client.GetAsync(POSITIONS_API);
            //    if (responseMessage.IsSuccessStatusCode)
            //    {
            //        responsePositionCollection = await responseMessage.Content.ReadAsAsync<List<PositionModel>>();
            //    }

            //    model.PositionCollection = responsePositionCollection;
            //    model.CompanyCollection = responseCompanyCollection;

            //    return View(model);
            //}

            //return Redirect("/" + EMPLOYEES_API + "/Index");
        }

        [HttpPost]
        public async Task<IActionResult> Update(EmployeeViewModel model)
        {
            EmployeeModel employee = model.EmployeeModel;

            var responseMessage = await PutAsync(EMPLOYEES_API, employee);
            if (responseMessage.IsSuccessStatusCode)
            {
                return Redirect("/" + EMPLOYEES_API + "/Index");
            }

            return Redirect("/" + EMPLOYEES_API + "/Update/" + employee.Id.Identificator);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(uint id)
        {
            await DeleteAsync(EMPLOYEES_API + "/" + id);

            return Redirect("/" + EMPLOYEES_API + "/Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private async Task<EmployeeViewModel> GetViewModelWithCollectionsAsync()
        {
            List<CompanyModel> responseCompanyCollection = await GetResultCollectionAsync<CompanyModel>(COMPANIES_API);

            List<PositionModel> responsePositionCollection = await GetResultCollectionAsync<PositionModel>(POSITIONS_API);

            if (responseCompanyCollection != null && responsePositionCollection != null)
            {
                EmployeeViewModel model = new EmployeeViewModel
                {
                    CompanyCollection = responseCompanyCollection,
                    PositionCollection = responsePositionCollection
                };

                return model;
            }
            else
            {
                return null;
            }
        }
    }
}

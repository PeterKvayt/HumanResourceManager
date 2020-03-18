using BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Models;
using PresentationLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
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
            var (responseEmployeeCollection, statusCode) = await GetResultCollectionAsync<EmployeeModel>(EMPLOYEES_API);

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
            var (model, statusCode) = await GetViewModelWithCollectionsAsync();

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
                var (model, statusCode) = await GetViewModelWithCollectionsAsync();
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
            return View(new ErrorViewModel());
        }

        private async Task<(EmployeeViewModel, HttpStatusCode)> GetViewModelWithCollectionsAsync()
        {
            var companyResponse = await GetResultCollectionAsync<CompanyModel>(COMPANIES_API);

            var positionRespnse = await GetResultCollectionAsync<PositionModel>(POSITIONS_API);

            if (companyResponse.Item1 != null && positionRespnse.Item1 != null)
            {
                EmployeeViewModel model = new EmployeeViewModel
                {
                    CompanyCollection = companyResponse.Item1,
                    PositionCollection = positionRespnse.Item1
                };

                return (model, HttpStatusCode.OK);
            }
            else
            {
                var notFoundStatus = HttpStatusCode.NotFound;

                if (companyResponse.Item2 == notFoundStatus && positionRespnse.Item2 == notFoundStatus)
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

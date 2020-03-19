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
                return RedirectToAction("Error", new { code = statusCode });
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
                return RedirectToAction("Error", new { code = statusCode });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeViewModel model)
        {
            EmployeeModel employee = model.EmployeeModel;

            var statusCode = await PostAsync(EMPLOYEES_API, employee);

            if (statusCode == HttpStatusCode.OK)
            {
                return Redirect("/" + EMPLOYEES_API);
            }
            else
            {
                return RedirectToAction("Error", new { code = statusCode });
            }
        }

        [HttpGet]
        public async Task<IActionResult> Update(uint? id)
        {
            var (employeeModel, emolyeeStatusCode) = await GetResultAsync(EMPLOYEES_API + "/" + id);

            if (employeeModel != null)
            {
                var (model, collectionsStatusCode) = await GetViewModelWithCollectionsAsync();
                if (model != null)
                {
                    model.EmployeeModel = employeeModel;

                    return View(model);
                }
                else
                {
                    return RedirectToAction("Error", new { code = collectionsStatusCode });
                }
            }
            else
            {
                return RedirectToAction("Error", new { code = emolyeeStatusCode });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(EmployeeViewModel model)
        {
            EmployeeModel employee = model.EmployeeModel;

            var statusCode = await PutAsync(EMPLOYEES_API, employee);

            if (statusCode == HttpStatusCode.OK)
            {
                return Redirect("/" + EMPLOYEES_API);
            }
            else
            {
                return RedirectToAction("Error", new { code = statusCode });
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(uint? id)
        {
            var statusCode = await DeleteAsync(EMPLOYEES_API + "/" + id);

            if (statusCode == HttpStatusCode.OK)
            {
                return Redirect("/" + EMPLOYEES_API);
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

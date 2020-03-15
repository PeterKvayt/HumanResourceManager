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
    public class EmployeesController : Controller
    {
        private HttpClient _client;

        private const string EMPLOYEES_API = "Employees";

        private const string COMPANIES_API = "Companies";

        private const string POSITIONS_API = "Positions";

        public EmployeesController(HttpClient client)
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
            List<EmployeeModel> responseEmployeeCollection = new List<EmployeeModel> { };

            HttpResponseMessage responseMessage = await _client.GetAsync(EMPLOYEES_API);
            if (responseMessage.IsSuccessStatusCode)
            {
                responseEmployeeCollection = await responseMessage.Content.ReadAsAsync<List<EmployeeModel>>();
            }

            EmployeeViewModel model = new EmployeeViewModel
            {
                EmployeeCollection = responseEmployeeCollection
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            List<CompanyModel> responseCompanyCollection = new List<CompanyModel> { };

            HttpResponseMessage responseMessage = await _client.GetAsync(COMPANIES_API);
            if (responseMessage.IsSuccessStatusCode)
            {
                responseCompanyCollection = await responseMessage.Content.ReadAsAsync<List<CompanyModel>>();
            }

            List<PositionModel> responsePositionCollection = new List<PositionModel> { };

            responseMessage = await _client.GetAsync(POSITIONS_API);
            if (responseMessage.IsSuccessStatusCode)
            {
                responsePositionCollection = await responseMessage.Content.ReadAsAsync<List<PositionModel>>();
            }

            EmployeeViewModel model = new EmployeeViewModel
            {
                PositionCollection = responsePositionCollection,
                CompanyCollection = responseCompanyCollection
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeViewModel model)
        {
            EmployeeModel employee = model.EmployeeModel;

            HttpResponseMessage responseMessage = await _client.PostAsJsonAsync(EMPLOYEES_API, employee);

            if (responseMessage.IsSuccessStatusCode)
            {
                return Redirect("/" + EMPLOYEES_API + "/Index");
            }

            return Redirect("/" + EMPLOYEES_API + "/Create");
        }

        [HttpGet]
        public async Task<IActionResult> Update(uint id)
        {
            HttpResponseMessage responseMessage = await _client.GetAsync(EMPLOYEES_API + "/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                EmployeeViewModel model = new EmployeeViewModel
                {
                    EmployeeModel = await responseMessage.Content.ReadAsAsync<EmployeeModel>()
                };

                List<CompanyModel> responseCompanyCollection = new List<CompanyModel> { };

                responseMessage = await _client.GetAsync(COMPANIES_API);
                if (responseMessage.IsSuccessStatusCode)
                {
                    responseCompanyCollection = await responseMessage.Content.ReadAsAsync<List<CompanyModel>>();
                }

                List<PositionModel> responsePositionCollection = new List<PositionModel> { };

                responseMessage = await _client.GetAsync(POSITIONS_API);
                if (responseMessage.IsSuccessStatusCode)
                {
                    responsePositionCollection = await responseMessage.Content.ReadAsAsync<List<PositionModel>>();
                }

                model.PositionCollection = responsePositionCollection;
                model.CompanyCollection = responseCompanyCollection;

                return View(model);
            }

            return Redirect("/" + EMPLOYEES_API + "/Index");
        }

        [HttpPost]
        public async Task<IActionResult> Update(EmployeeViewModel model)
        {
            EmployeeModel employee = model.EmployeeModel;

            HttpResponseMessage responseMessage = await _client.PutAsJsonAsync(EMPLOYEES_API, employee);
            if (responseMessage.IsSuccessStatusCode)
            {
                return Redirect("/" + EMPLOYEES_API + "/Index");
            }

            return Redirect("/" + EMPLOYEES_API + "/Update/" + employee.Id.Identificator);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(uint id)
        {
            HttpResponseMessage responseMessage = await _client.DeleteAsync(EMPLOYEES_API + "/" + id);

            return Redirect("/" + EMPLOYEES_API + "/Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

using System;
using System.Collections.Generic;
using HumanResourceManager.DataAccessLayers;
using HumanResourceManager.Models;
using HumanResourceManager.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HumanResourceManager.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeDataAccessLayer employeeContext = new EmployeeDataAccessLayer();
        CompanyDataAccessLayer companyContext = new CompanyDataAccessLayer();
        PositionDataAccessLayer positionContext = new PositionDataAccessLayer();

        // Возвращает представление со всеми сотрудниками
        [HttpGet]
        public ActionResult Employees()
        {
            List<Employee> employees = new List<Employee>();
            employees = employeeContext.GetAllEmployees();

            return View(employees);
        }

        // Возвращает представление для создания сотрудника
        [HttpGet]
        public ActionResult Create()
        {
            List<Company> companies = new List<Company>();
            List<Position> positions = new List<Position>();

            companies = companyContext.GetAllCompanies();
            positions = positionContext.GetAllPositions();

            var model = new EmployeeViewModel(companies, positions, new Employee());

            return View(model);
        }

        // Принимает из представления параметры и создает нового сотрудника
        [HttpPost]
        public ActionResult Create([Bind]Employee employee, string positionParams, string companyParams)
        {
            if (!string.IsNullOrEmpty(employee.GetName()) && !string.IsNullOrWhiteSpace(employee.GetName()) &&
                !string.IsNullOrEmpty(employee.GetSurname()) && !string.IsNullOrWhiteSpace(employee.GetSurname()) &&
                !string.IsNullOrEmpty(employee.GetMiddlename()) && !string.IsNullOrWhiteSpace(employee.GetMiddlename()) &&
                !string.IsNullOrEmpty(positionParams) && !string.IsNullOrWhiteSpace(positionParams) &&
                !string.IsNullOrEmpty(companyParams) && !string.IsNullOrWhiteSpace(companyParams)
                )
            {
                Position position = Position.DesirializeToPosition(positionParams);

                //Company company = Company.DesirializeToCompany(companyParams);

                //employee.GetName() = employee.GetName();
                //employee.Surname = employee.Surname;
                //employee.MiddleName = employee.MiddleName;
                //employee.Position = position;
                //employee.Company = company;

                //if (employee.DateOfEmployment == new DateTime())
                //{
                //    employee.DateOfEmployment = DateTime.Now;
                //}
                //else
                //{
                //    employee.DateOfEmployment = employee.DateOfEmployment;
                //}

                employeeContext.AddEmployee(employee);

                return Redirect("/Employee/Employees");
            }
            else
            {
                return Redirect("/Employee/Create");
            }
        }

        // Возвращает представление для обновления сотрудника
        [HttpGet]
        public ActionResult Update(int? id)
        {
            if (id != null && employeeContext.IsEmployeeExist((int)id))
            {
                List<Company> companies = new List<Company>();
                List<Position> positions = new List<Position>();

                companies = companyContext.GetAllCompanies();
                positions = positionContext.GetAllPositions();
                Employee employee = employeeContext.GetEmployeeData((int)id);
                

                var model = new EmployeeViewModel(companies, positions, employee);

                return View(model);
            }
            else
            {
                return NotFound();
            }

        }

        // Принимает из представления параметры и обновляет сотрудника
        [HttpPost]
        public ActionResult Update([Bind]Employee employee, string positionParams, string companyParams)
        {
            if (!string.IsNullOrEmpty(employee.GetName()) && !string.IsNullOrWhiteSpace(employee.GetName()) &&
                !string.IsNullOrEmpty(employee.GetSurname()) && !string.IsNullOrWhiteSpace(employee.GetSurname()) &&
                !string.IsNullOrEmpty(employee.GetMiddlename()) && !string.IsNullOrWhiteSpace(employee.GetMiddlename()) &&
                !string.IsNullOrEmpty(positionParams) && !string.IsNullOrWhiteSpace(positionParams) &&
                !string.IsNullOrEmpty(companyParams) && !string.IsNullOrWhiteSpace(companyParams)
                )
            {
                Position position = Position.DesirializeToPosition(positionParams);
                //Company company = Company.DesirializeToCompany(companyParams);

                //employee.GetName() = employee.GetName();
                //employee.Surname = employee.Surname;
                //employee.MiddleName = employee.MiddleName;
                //employee.Position = position;
                //employee.Company = company;

                //if (employee.DateOfEmployment == new DateTime())
                //{
                //    employee.DateOfEmployment = DateTime.Now;
                //}
                //else
                //{
                //    employee.DateOfEmployment = employee.DateOfEmployment;
                //}

                employeeContext.UpdateEmployee(employee);

                return Redirect("/Employee/Employees");
            }
            else
            {
                return Redirect("/Employee/Update");
            }
        }

        // Принимает из представления параметры и удаляет сотрудника
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id != null && employeeContext.IsEmployeeExist((int)id))
            {
                employeeContext.DeleteEmployee((int)id);

                return Redirect("/Employee/Employees");
            }
            else
            {
                return NotFound();
            }

            
        }
    }
}
using System.Collections.Generic;
using HumanResourceManager.DataAccessLayers;
using HumanResourceManager.Models;
using HumanResourceManager.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HumanResourceManager.Controllers
{
    public class CompanyController : Controller
    {
        CompanyDataAccessLayer companyContext = new CompanyDataAccessLayer();
        ActivityTypeDataAccessLayer activityTypeContext = new ActivityTypeDataAccessLayer();
        OrganizationalTypeDataAccessLayer organizationalTypeContext = new OrganizationalTypeDataAccessLayer();

        // Возвращает представление со всеми компаниями
        [HttpGet]
        public ActionResult Companies()
        {
            List<Company> companies = companyContext.GetAllCompanies();

            return View(companies);
        }

        // Возвращает представление для создания компании
        [HttpGet]
        public ActionResult Create()
        {
            List<ActivityType> activityTypes = activityTypeContext.GetAllActivityTypes();
            List<OrganizationalType> organizationalTypes = organizationalTypeContext.GetAllOrganizationalTypes();
            Company company = new Company();

            var model = new CompanyViewModel(organizationalTypes, activityTypes, company);

            return View(model);
        }

        // Принимает из представления параметры и создает новую компанию
        [HttpPost]
        public ActionResult Create(Company company, string OrganizationalTypeParams, string ActivityTypeParams)
        {
            if (!string.IsNullOrEmpty(company.Name) && !string.IsNullOrWhiteSpace(company.Name) &&
                !string.IsNullOrEmpty(OrganizationalTypeParams) && !string.IsNullOrWhiteSpace(OrganizationalTypeParams) &&
                !string.IsNullOrEmpty(ActivityTypeParams) && !string.IsNullOrWhiteSpace(ActivityTypeParams) 
                )
            {
                OrganizationalType organizationalType = OrganizationalType.DesirializeToOrganizationalType(OrganizationalTypeParams);

                ActivityType activityType = ActivityType.DesirializeToActivityType(ActivityTypeParams);

                company.OrganizationalType = organizationalType;
                company.ActivityType = activityType;

                companyContext.AddCompany(company);

                return Redirect("/Company/Companies");
            }
            else
            {
                return Redirect("/Company/Create");
            }
        }

        // Возвращает представление для обновления компании
        [HttpGet]
        public ActionResult Update(int? id)
        {
            if (id != null && companyContext.IsCompanyExist((int)id))
            {
                List<ActivityType> activityTypes = activityTypeContext.GetAllActivityTypes();
                List<OrganizationalType> organizationalTypes = organizationalTypeContext.GetAllOrganizationalTypes();
                Company company = companyContext.GetCompanyData((int)id);

                var model = new CompanyViewModel(organizationalTypes, activityTypes, company);

                return View(model);
            }
            else
            {
                return NotFound();
            }

        }

        // Принимает из представления параметры и обновляет компанию
        [HttpPost]
        public ActionResult Update(Company company, string OrganizationalTypeParams, string ActivityTypeParams)
        {
            if (!string.IsNullOrEmpty(company.Name) && !string.IsNullOrWhiteSpace(company.Name) &&
                !string.IsNullOrEmpty(OrganizationalTypeParams) && !string.IsNullOrWhiteSpace(OrganizationalTypeParams) &&
                !string.IsNullOrEmpty(ActivityTypeParams) && !string.IsNullOrWhiteSpace(ActivityTypeParams)
                )
            {
                OrganizationalType organizationalType = OrganizationalType.DesirializeToOrganizationalType(OrganizationalTypeParams);

                ActivityType activityType = ActivityType.DesirializeToActivityType(ActivityTypeParams);

                company.OrganizationalType = organizationalType;
                company.ActivityType = activityType;

                companyContext.UpdateCompany(company);

                return Redirect("/Company/Companies");
            }
            else
            {
                return Redirect("/Company/Update");
            }
        }

        // Принимает из представления параметры и удаляет компанию
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id != null && companyContext.IsCompanyExist((int)id))
            {
                companyContext.DeleteEmployee((int)id);

                return Redirect("/Company/Companies");
            }
            else
            {
                return NotFound();
            }
        }
    }
}
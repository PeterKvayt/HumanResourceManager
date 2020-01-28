using System.Collections.Generic;
using HumanResourceManager.DataAccessLayers;
using HumanResourceManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace HumanResourceManager.Controllers
{
    public class OrganizationalTypeController : Controller
    {
        OrganizationalTypeDataAccessLayer organizationalTypeContext = new OrganizationalTypeDataAccessLayer();

        // Возвращает представление со всеми организационно-правовыми формами
        [HttpGet]
        public ActionResult OrganizationalTypes()
        {
            List<OrganizationalType> organizationalTypes = organizationalTypeContext.GetAllOrganizationalTypes();

            return View(organizationalTypes);
        }

        // Возвращает представление для создания организационно-правовой формы
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // Принимает из представления параметры и создает новую организационно-правовую форму
        [HttpPost]
        public ActionResult Create(string name)
        {
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrWhiteSpace(name))
            {
                organizationalTypeContext.AddOrganizationalType(name);

                return Redirect("/OrganizationalType/OrganizationalTypes");
            }

            return Redirect("/OrganizationalType/Create");
        }

        // Возвращает представление для обновления организационно-правовой формы
        [HttpGet]
        public ActionResult Update(int? id)
        {
            if (id != null && organizationalTypeContext.IsOrganizationalTypeExist((int)id))
            {
                OrganizationalType organizationalType = organizationalTypeContext.GetOrganizationalTypeData((int)id);

                return View(organizationalType);
            }
            else
            {
                return NotFound();
            }

        }

        // Принимает из представления параметры и обновляет организационно-правовую форму
        [HttpPost]
        public ActionResult Update(string name, string id)
        {
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrWhiteSpace(name) &&
                !string.IsNullOrEmpty(id) && !string.IsNullOrWhiteSpace(id)
                )
            {
                if (int.TryParse(id, out int result))
                {
                    organizationalTypeContext.UpdateOrganizationalType(new OrganizationalType(result, name));

                    return Redirect("/OrganizationalType/OrganizationalTypes");
                }
                else
                {
                    return Redirect("/OrganizationalType/Update");
                }
            }

            return Redirect("/OrganizationalType/Update");
        }

        // Принимает из представления параметры и удаляет организационно-правовую форму
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id != null && organizationalTypeContext.IsOrganizationalTypeExist((int)id))
            {
                organizationalTypeContext.DeleteOrganizationalType((int)id);

                return Redirect("/OrganizationalType/OrganizationalTypes");
            }
            else
            {
                return NotFound();
            }
        }
    }
}
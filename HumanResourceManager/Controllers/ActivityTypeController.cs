using System.Collections.Generic;
using HumanResourceManager.DataAccessLayers;
using HumanResourceManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace HumanResourceManager.Controllers
{
    public class ActivityTypeController : Controller
    {
        ActivityTypeDataAccessLayer activityTypeContext = new ActivityTypeDataAccessLayer();

        // Возвращает представление со всеми видами деятельности компаний
        [HttpGet]
        public ActionResult ActivityTypes()
        {
            List<ActivityType> activityType = activityTypeContext.GetAllActivityTypes();

            return View(activityType);
        }

        // Возвращает представление для создания вида деятельности компаний
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // Принимает из представления параметры и создает новый вид деятельности компании
        [HttpPost]
        public ActionResult Create(string name)
        {
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrWhiteSpace(name))
            {
                activityTypeContext.AddActivityType(name);

                return Redirect("/ActivityType/ActivityTypes");
            }

            return Redirect("/ActivityType/Create");
        }

        // Возвращает представление для обновления вида деятельности компаний
        [HttpGet]
        public ActionResult Update(int? id)
        {
            if (id != null && activityTypeContext.IsActivityTypeExist((int)id))
            {
                ActivityType activityType = activityTypeContext.GetActivityTypeData((int)id);

                return View(activityType);
            }
            else
            {
                return NotFound();
            }

        }

        // Принимает из представления параметры и обновляет вид деятельности компании
        [HttpPost]
        public ActionResult Update(string name, string id)
        {
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrWhiteSpace(name) &&
                !string.IsNullOrEmpty(id) && !string.IsNullOrWhiteSpace(id)
                )
            {
                if (int.TryParse(id, out int result))
                {
                    activityTypeContext.UpdateActivityType(new ActivityType(result, name));

                    return Redirect("/ActivityType/ActivityTypes");
                }
                else
                {
                    return Redirect("/ActivityType/Update");
                }
            }

            return Redirect("/ActivityType/Update");
        }

        // Принимает из представления параметры и удаляет вид деятельности компании
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id != null && activityTypeContext.IsActivityTypeExist((int)id))
            {
                activityTypeContext.DeleteActivityType((int)id);

                return Redirect("/ActivityType/ActivityTypes");
            }
            else
            {
                return NotFound();
            }
        }
    }
}
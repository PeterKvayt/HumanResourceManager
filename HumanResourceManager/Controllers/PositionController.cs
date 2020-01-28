using System.Collections.Generic;
using HumanResourceManager.DataAccessLayers;
using HumanResourceManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace HumanResourceManager.Controllers
{
    public class PositionController : Controller
    {
        PositionDataAccessLayer positionContext = new PositionDataAccessLayer();

        // Возвращает представление со всеми должностями
        [HttpGet]
        public ActionResult Positions()
        {
            List<Position> positions = positionContext.GetAllPositions();

            return View(positions);
        }

        // Возвращает представление для создания должности
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // Принимает из представления параметры и создает новую должность
        [HttpPost]
        public ActionResult Create(string name)
        {
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrWhiteSpace(name))
            {
                positionContext.AddPosition(name);

                return Redirect("/Position/Positions");
            }

            return Redirect("/Position/Create");
        }

        // Возвращает представление для обновления должности
        [HttpGet]
        public ActionResult Update(int? id)
        {
            if (id != null && positionContext.IsPositionExist((int)id))
            {
                Position position = positionContext.GetPositionData((int)id);

                return View(position);
            }
            else
            {
                return NotFound();
            }

        }

        // Принимает из представления параметры и обновляет должность
        [HttpPost]
        public ActionResult Update(string name, string id)
        {
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrWhiteSpace(name) &&
                !string.IsNullOrEmpty(id) && !string.IsNullOrWhiteSpace(id)
                )
            {
                if (int.TryParse(id, out int result))
                {
                    positionContext.UpdatePosition(new Position(result, name));

                    return Redirect("/Position/Positions");
                }
                else
                {
                    return Redirect("/Position/Update");
                }
            }

            return Redirect("/Position/Update");
        }

        // Принимает из представления параметры и удаляет должность
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id != null && positionContext.IsPositionExist((int)id))
            {
                positionContext.DeleteEmployee((int)id);

                return Redirect("/Position/Positions");
            }
            else
            {
                return Redirect("/Position/Positions");
            }
        }
    }
}
using HumanResourceManager.Models;
using System.Collections.Generic;

namespace HumanResourceManager.DataAccessLayers
{
    public class PositionDataAccessLayer : DataAccessLayer
    {
        // Возвращает всю информацию о всех должностях
        public List<Position> GetAllPositions()
        {
            List<Position> positions = ToPosition(GetAll("spGetAllPositions"));

            return positions;
        }

        // Добавляет новую должность   
        public void AddPosition(string name)
        {
            Add(name, "spAddPosition");
        }

        // Обновляет данные о должности
        public void UpdatePosition(Position position)
        {
            Update(position, "spUpdatePosition");
        }

        // Удаляет должность из бд  
        public void DeleteEmployee(int id)
        {
            Delete(id, "spDeletePosition");
        }

        //Возвращает должность по ID
        public Position GetPositionData(int id)
        {
            Position position = ToPosition(GetParticularData(id, "spGetPosition"));

            return position;
        }

        //Проверяет, существует ли должность с таким id
        public bool IsPositionExist(int id)
        {
            return IsExist(id, "spIsPositionExist");
        }
    }
}

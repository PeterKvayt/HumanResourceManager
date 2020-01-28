using HumanResourceManager.Models;
using System.Collections.Generic;

namespace HumanResourceManager.DataAccessLayers
{
    public class ActivityTypeDataAccessLayer : DataAccessLayer
    {
        // Возвращает всю информацию о видах деятельности
        public List<ActivityType> GetAllActivityTypes()
        {
            List<ActivityType> activityTypes = ToActivityType(GetAll("spGetAllActivityTypes"));

            return activityTypes;
        }

        // Добавляет новый вид деятельности   
        public void AddActivityType(string name)
        {
            Add(name, "spAddActivityType");
        }

        // Обновляет данные о виде деятельности
        public void UpdateActivityType(ActivityType activityType)
        {
            Update(activityType, "spUpdateActivityType");
        }

        // Удаляет вид деятельности из бд  
        public void DeleteActivityType(int id)
        {
            Delete(id, "spDeleteActivityType");
        }

        //Возвращает вид деятельности по ID
        public ActivityType GetActivityTypeData(int id)
        {
            ActivityType activityType = ToActivityType(GetParticularData(id, "spGetActivityType"));

            return activityType;
        }

        //Проверяет, существует ли вид деятельности с таким id
        public bool IsActivityTypeExist(int id)
        {
            return IsExist(id, "spIsActivityTypeExist");
        }
    }
}

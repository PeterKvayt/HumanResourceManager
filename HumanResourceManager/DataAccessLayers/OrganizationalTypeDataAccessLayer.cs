using HumanResourceManager.Models;
using System.Collections.Generic;


namespace HumanResourceManager.DataAccessLayers
{
    public class OrganizationalTypeDataAccessLayer : DataAccessLayer
    {
        // Возвращает всю информацию о видах организаций
        public List<OrganizationalType> GetAllOrganizationalTypes()
        {
            List<OrganizationalType> organizationalTypes = ToOrganizationalType(GetAll("spGetAllOrganizationalTypes"));

            return organizationalTypes;
        }

        // Добавляет новый вид организаций   
        public void AddOrganizationalType(string name)
        {
            Add(name, "spAddOrganizationalType");
        }

        // Обновляет данные о виде организации
        public void UpdateOrganizationalType(OrganizationalType organizationalType)
        {
            Update(organizationalType, "spUpdateOrganizationalType");
        }

        // Удаляет вид организации из бд  
        public void DeleteOrganizationalType(int id)
        {
            Delete(id, "spDeleteOrganizationalType");
        }

        //Возвращает виде деятельности по ID
        public OrganizationalType GetOrganizationalTypeData(int id)
        {
            OrganizationalType organizationalType = ToOrganizationalType(GetParticularData(id, "spGetOrganizationalType"));

            return organizationalType;
        }

        //Проверяет, существует ли тип организации с таким id
        public bool IsOrganizationalTypeExist(int id)
        {
            return IsExist(id, "spIsOrganizationalTypeExist");
        }
    }
}
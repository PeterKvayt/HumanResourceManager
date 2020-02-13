using System;

namespace HumanResourceManager.Models
{
    public class CompanyData
    {
        public int Id { get; set; }
        public int OrganizationalTypeId { get; set; }
        public int ActivityTypeId { get; set; }
        public string Name { get; set; }
        public int? Size { get; set; }

        public CompanyData(int id, int organizationalTypeId, int activityTypeId, string name, int? size)
        {
            Id = id;
            OrganizationalTypeId = organizationalTypeId;
            ActivityTypeId = activityTypeId;
            Name = name;
            Size = size == null ? 0 : size;
        }

        public CompanyData(int organizationalTypeId, int activityTypeId, string name, int? size)
        {
            OrganizationalTypeId = organizationalTypeId;
            ActivityTypeId = activityTypeId;
            Name = name;
            Size = size == null ? 0 : size;
        }

        public CompanyData() { }

        // Возвращает объект в виде строки с параметрами
        //public string SerializeToString()
        //{
        //    string result = $"{Id.ToString()}~{OrganizationalType.Id}~{OrganizationalType.Name}~{ActivityType.Id}~{ActivityType.Name}~{Name}~{Size}";

        //    return result;
        //}

        // Собирает объект из параметров
        //public static CompanyData DesirializeToCompany(string value)
        //{
        //    string[] parameters = value.Split('~');

        //    return new CompanyData(
            
        //        Convert.ToInt32(parameters[0]),

        //        new OrganizationalType(

        //            Convert.ToInt32(parameters[1]),
        //            parameters[2]
        //            ),

        //        new ActivityType(

        //            Convert.ToInt32(parameters[3]),
        //            parameters[4]
        //            ),

        //        parameters[5],

        //        Convert.ToInt32(parameters[6])

        //    );
        //}
    }
}

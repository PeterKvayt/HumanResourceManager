using System;

namespace HumanResourceManager.Models
{
    public class Company
    {
        public int Id { get; set; }
        public OrganizationalType OrganizationalType { get; set; }
        public ActivityType ActivityType { get; set; }
        public string Name { get; set; }
        public int? Size { get; set; }

        public Company(int id, OrganizationalType organizationalType, ActivityType activityType, string name, int? size)
        {
            Id = id;
            OrganizationalType = organizationalType;
            ActivityType = activityType;
            Name = name;
            Size = size == null ? 0 : size;
        }

        public Company(OrganizationalType organizationalType, ActivityType activityType, string name, int? size)
        {
            OrganizationalType = organizationalType;
            ActivityType = activityType;
            Name = name;
            Size = size == null ? 0 : size;
        }

        public Company()
        {
        }

        // Возвращает объект в виде строки с параметрами
        public string SerializeToString()
        {
            string result = $"{Id.ToString()}~{OrganizationalType.Id}~{OrganizationalType.Name}~{ActivityType.Id}~{ActivityType.Name}~{Name}~{Size}";

            return result;
        }

        // Собирает объект из параметров
        public static Company DesirializeToCompany(string value)
        {
            string[] parameters = value.Split('~');

            return new Company(
            
                Convert.ToInt32(parameters[0]),

                new OrganizationalType(

                    Convert.ToInt32(parameters[1]),
                    parameters[2]
                    ),

                new ActivityType(

                    Convert.ToInt32(parameters[3]),
                    parameters[4]
                    ),

                parameters[5],

                Convert.ToInt32(parameters[6])

            );
        }
    }
}

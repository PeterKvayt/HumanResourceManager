using System;

namespace HumanResourceManager.Models
{
    public class EmployeeData
    {
        public int Id { get; set; }
        public int PositionId { get; set; }
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Middlename { get; set; }
        public DateTime DateOfEmployment { get; set; }

        public EmployeeData() { }

        public EmployeeData(int id, int position, int company, string name, string surname, string middleName, DateTime date)
        {
            Id = id;
            PositionId = position;
            CompanyId = company;
            Name = name;
            Surname = surname;
            Middlename = middleName;
            DateOfEmployment = date;
        }

        public EmployeeData(int position, int company, string name, string surname, string middleName, DateTime date)
        {
            PositionId = position;
            CompanyId = company;
            Name = name;
            Surname = surname;
            Middlename = middleName;
            DateOfEmployment = date;
        }
    }
}

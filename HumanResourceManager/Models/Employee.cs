using System;

namespace HumanResourceManager.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public Position Position { get; set; }
        public Company Company { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public DateTime DateOfEmployment { get; set; }

        public Employee(int id, Position position, Company company, string name, string surname, string middleName, DateTime date)
        {
            Id = id;
            Position = position;
            Company = company;
            Name = name;
            Surname = surname;
            MiddleName = middleName;
            DateOfEmployment = date;
        }

        public Employee(Position position, Company company, string name, string surname, string middleName, DateTime date)
        {
            Position = position;
            Company = company;
            Name = name;
            Surname = surname;
            MiddleName = middleName;
            DateOfEmployment = date;
        }

        public Employee():base()
        {

        }
    }
}

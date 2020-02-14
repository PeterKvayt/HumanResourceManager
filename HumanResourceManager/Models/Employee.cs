using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanResourceManager.Models
{
    public class Employee
    {
        private EmployeeData m_EmployeeData;

        public Company Company { get; set; }

        public Position Position { get; set; }

        public Employee(EmployeeData employeeData, Company company, Position position)
        {
            m_EmployeeData = employeeData;
            Company = company;
            Position = position;
        }

        public Employee() { }

        public int GetId()
        {
            return m_EmployeeData.Id;
        }

        public string GetName()
        {
            return m_EmployeeData.Name;
        }

        public string GetSurname()
        {
            return m_EmployeeData.Surname;
        }

        public string GetMiddlename()
        {
            return m_EmployeeData.Middlename;
        }

        public DateTime GetDateOfEmployment()
        {
            return m_EmployeeData.DateOfEmployment;
        }
    }
}

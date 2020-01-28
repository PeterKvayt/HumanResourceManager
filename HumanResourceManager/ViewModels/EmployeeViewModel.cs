using HumanResourceManager.Models;
using System.Collections.Generic;

namespace HumanResourceManager.ViewModels
{
    public class EmployeeViewModel
    {
        public List<Company> Companies { get; }
        public List<Position> Positions { get; }
        public Employee Employee { get; set; }

        public string positionParams { get; set; }
        public string companyParams { get; set; }

        public EmployeeViewModel(List<Company> companies, List<Position> positions, Employee employee)
        {
            Companies = companies;
            Positions = positions;
            Employee = employee;
        }
    }
}

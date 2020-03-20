using PresentationLayer.Models;
using System.Collections.Generic;

namespace PresentationLayer.ViewModels
{
    public class EmployeeViewModel
    {
        public EmployeeModel EmployeeModel { get; set; }

        public List<EmployeeModel> EmployeeCollection { get; set; }

        public List<PositionModel> PositionCollection { get; set; }

        public List<CompanyModel> CompanyCollection { get; set; }
    }
}

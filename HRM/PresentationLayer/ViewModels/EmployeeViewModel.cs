using PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

using CommonClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationLayer.Models
{
    public class EmployeeModel
    {
        public IdType Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string MiddleName { get; set; }

        public CompanyModel Company { get; set; }

        public PositionModel Position { get; set; }

        public DateTime DateOfEmployment { get; set; }
    }
}

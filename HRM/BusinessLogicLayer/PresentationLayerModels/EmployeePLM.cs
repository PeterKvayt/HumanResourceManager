using BusinessLogicLayer.DataTransferObjects;
using CommonClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.PresentationLayerModels
{
    class EmployeePLM
    {
        public IdType Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string MiddleName { get; set; }

        public CompanyDTO Company { get; set; }

        public PositionDTO Position { get; set; }

        public DateTime DateOfEmployment { get; set; }
    }
}

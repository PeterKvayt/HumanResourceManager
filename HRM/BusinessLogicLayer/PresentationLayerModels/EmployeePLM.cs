using BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.Interfaces;
using CommonClasses;
using System;

namespace BusinessLogicLayer.PresentationLayerModels
{
    class EmployeePLM : IPresentationLayerModel
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

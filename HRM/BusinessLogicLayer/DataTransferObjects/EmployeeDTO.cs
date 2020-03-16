using BusinessLogicLayer.Interfaces;
using CommonClasses;
using System;
using System.ComponentModel.DataAnnotations;

namespace BusinessLogicLayer.DataTransferObjects
{
    public class EmployeeDTO : IDataTransferObject
    {
        public IdType Id { get; set; }

        [StringLength(20)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Surname { get; set; }

        [StringLength(20)]
        public string MiddleName { get; set; }

        public CompanyDTO Company { get; set; }

        public PositionDTO Position { get; set; }

        public DateTime DateOfEmployment { get; set; }
    }
}

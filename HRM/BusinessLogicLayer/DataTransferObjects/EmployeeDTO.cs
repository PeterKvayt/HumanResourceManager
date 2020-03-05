using BusinessLogicLayer.Interfaces;
using CommonClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.DataTransferObjects
{
    public class EmployeeDTO
    {
        public IdType Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string MiddleName { get; set; }

        public IdType CompanyId { get; set; }

        public IdType PositionId { get; set; }

        public DateTime DateOfEmployment { get; set; }
    }
}

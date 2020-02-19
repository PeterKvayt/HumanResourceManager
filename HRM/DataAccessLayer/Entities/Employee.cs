using DataAccessLayer.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Entities
{
    class Employee
    {
        public IdType Id { get; set; }
        public FullName BigName { get; set; }
        public IdType CompanyId { get; set; }
        public IdType PositionId { get; set; }
        public DateTime DateOfEmployment { get; set; }
    }
}

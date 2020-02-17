using DataAccessLayer.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Entities
{
    class Employee
    {
        public IdType Id { get; set; }
        public FullName WholeName { get; set; }
        public Company Firm { get; set; }
        public Position WorkPosition { get; set; }
    }
}

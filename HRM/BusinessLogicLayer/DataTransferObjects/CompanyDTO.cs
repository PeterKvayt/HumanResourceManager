using BusinessLogicLayer.Interfaces;
using CommonClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.DataTransferObjects
{
    public class CompanyDTO : IDto
    {
        public IdType Id { get; set; }

        public string Name { get; set; }

        public IdType ActivityId { get; set; }

        public IdType LegalFormId { get; set; }
    }
}

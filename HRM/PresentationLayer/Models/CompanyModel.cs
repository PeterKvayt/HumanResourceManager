using CommonClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationLayer.Models
{
    public class CompanyModel
    {
        public IdType Id { get; set; }

        public string Name { get; set; }

        public ActivityTypeModel ActivityType { get; set; }

        public LegalFormModel LegalForm { get; set; }
    }
}

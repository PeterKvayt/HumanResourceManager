using PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationLayer.ViewModels
{
    public class CompanyViewModel
    {
        public CompanyModel CompanyModel { get; set; }

        public List<CompanyModel> CompanyModelCollection { get; set; }

        public List<ActivityTypeModel> ActivityTypeCollection { get; set; }

        public List<LegalFormModel> LegalFormCollection { get; set; }
    }
}

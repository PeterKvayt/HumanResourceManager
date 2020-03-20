using PresentationLayer.Models;
using System.Collections.Generic;

namespace PresentationLayer.ViewModels
{
    public class CompanyViewModel
    {
        public CompanyModel CompanyModel { get; set; }

        public List<CompanyModel> CompanyCollection { get; set; }

        public List<ActivityTypeModel> ActivityTypeCollection { get; set; }

        public List<LegalFormModel> LegalFormCollection { get; set; }
    }
}

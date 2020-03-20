using PresentationLayer.Models;
using System.Collections.Generic;

namespace PresentationLayer.ViewModels
{
    public class LegalFormViewModel
    {
        public LegalFormModel LegalFormModel { get; set; }

        public List<LegalFormModel> LegalFormCollection { get; set; }
    }
}

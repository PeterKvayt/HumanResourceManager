using PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationLayer.ViewModels
{
    public class LegalFormViewModel
    {
        public LegalFormModel LegalFormModel { get; set; }

        public List<LegalFormModel> LegalFormModelCollection { get; set; }
    }
}

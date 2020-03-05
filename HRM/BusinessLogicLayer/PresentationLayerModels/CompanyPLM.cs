using BusinessLogicLayer.DataTransferObjects;
using CommonClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.PresentationLayerModels
{
    class CompanyPLM
    {
        public IdType Id { get; set; }

        public string Name { get; set; }

        public ActivityTypeDTO ActivityType { get; set; }

        public LegalFormDTO LegalForm { get; set; }
    }
}

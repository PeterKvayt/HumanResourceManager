using BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.Interfaces;
using CommonClasses;

namespace BusinessLogicLayer.PresentationLayerModels
{
    class CompanyPLM : IPresentationLayerModel
    {
        public IdType Id { get; set; }

        public string Name { get; set; }

        public ActivityTypeDTO ActivityType { get; set; }

        public LegalFormDTO LegalForm { get; set; }
    }
}

using BusinessLogicLayer.Interfaces;
using CommonClasses;

namespace BusinessLogicLayer.PresentationLayerModels
{
    class LegalFormPLM : IPresentationLayerModel
    {
        public IdType Id { get; set; }

        public string Name { get; set; }
    }
}

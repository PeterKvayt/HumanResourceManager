using BusinessLogicLayer.Interfaces;
using CommonClasses;

namespace BusinessLogicLayer.PresentationLayerModels
{
    class PositionPLM : IPresentationLayerModel
    {
        public IdType Id { get; set; }

        public string Name { get; set; }
    }
}

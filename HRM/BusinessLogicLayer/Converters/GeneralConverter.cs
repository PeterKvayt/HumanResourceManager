using BusinessLogicLayer.Mapper;
using DataAccessLayer.Interfaces;

namespace BusinessLogicLayer.Converters
{
    abstract class GeneralConverter<DataTransferObject, PresentationLayerModel> 
        where DataTransferObject: new()
        where PresentationLayerModel: new()
    {
        protected IUnitOfWork _dataBase;

        public virtual PresentationLayerModel Convert(DataTransferObject item)
        {
            return AutoMapper<PresentationLayerModel>.Map(item);
        }

        public virtual DataTransferObject Convert(PresentationLayerModel item)
        {
            return AutoMapper<DataTransferObject>.Map(item);
        }
    }
}

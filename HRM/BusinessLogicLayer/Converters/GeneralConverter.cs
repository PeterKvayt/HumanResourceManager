using BusinessLogicLayer.Mapper;
using DataAccessLayer.Interfaces;

namespace BusinessLogicLayer.Converters
{
    abstract class GeneralConverter<DataBaseEntity, DataBaseObject> 
        where DataBaseEntity: new()
        where DataBaseObject: new()
    {
        protected IUnitOfWork _dataBase;

        public virtual DataBaseObject Convert(DataBaseEntity item)
        {
            return AutoMapper<DataBaseObject>.Map(item);
        }

        public virtual DataBaseEntity Convert(DataBaseObject item)
        {
            return AutoMapper<DataBaseEntity>.Map(item);
        }
    }
}

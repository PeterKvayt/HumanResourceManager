using BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Converters
{
    class LegalFormConverter : GeneralConverter<LegalForm, LegalFormDTO>, IConverter<LegalForm, LegalFormDTO>
    {
        public LegalFormConverter(IUnitOfWork dataBase)
        {
            _dataBase = dataBase;
        }

        public LegalForm Convert(LegalFormDTO dtoItem)
        {
            var resultEntityItem = new LegalForm
            {
                Id = dtoItem.Id,
                Name = dtoItem.Name
            };

            return resultEntityItem;
        }

        public LegalFormDTO Convert(LegalForm entityItem)
        {
            var resultDTO = new LegalFormDTO
            {
                Id = entityItem.Id,
                Name = entityItem.Name
            };

            return resultDTO;
        }
    }
}

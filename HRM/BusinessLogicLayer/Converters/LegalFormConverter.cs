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
    }
}

using BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.Interfaces;
using CommonClasses;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System.Collections.Generic;

namespace BusinessLogicLayer.Services
{
    class LegalFormService : GeneralService<LegalForm, LegalFormDTO>, IService<LegalFormDTO>
    {
        public LegalFormService(IUnitOfWork dataBase)
        {
            _dataBase = dataBase;
        }

        public void Create(LegalFormDTO item)
        {
            Create(item, _dataBase.LegalForms);
        }

        public void Delete(IdType id)
        {
            Delete(id, _dataBase.LegalForms);
        }

        public bool Exists(IdType id)
        {
            return Exists(id, _dataBase.LegalForms);
        }

        public LegalFormDTO Get(IdType id)
        {
            return Get(id, _dataBase.LegalForms);
        }

        public IEnumerable<LegalFormDTO> GetAll()
        {
            return GetAll(_dataBase.LegalForms);
        }

        public void Update(LegalFormDTO item)
        {
            Update(item, _dataBase.LegalForms);
        }
    }
}

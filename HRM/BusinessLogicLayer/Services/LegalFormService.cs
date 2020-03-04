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
        private IRepository<LegalForm> _repository;

        public LegalFormService(IUnitOfWork dataBase)
        {
            _repository = dataBase.LegalForms;
        }

        public void Create(LegalFormDTO item)
        {
            Create(item, _repository);
        }

        public void Delete(IdType id)
        {
            Delete(id, _repository);
        }

        public LegalFormDTO Get(IdType id)
        {
            return Get(id, _repository);
        }

        public IEnumerable<LegalFormDTO> GetAll()
        {
            return GetAll(_repository);
        }

        public void Update(LegalFormDTO item)
        {
            Update(item, _repository);
        }
    }
}

using BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System.Collections.Generic;
using BusinessLogicLayer.Converters;

namespace BusinessLogicLayer.Services
{
    class LegalFormService : GeneralService<LegalFormDTO, LegalForm>, IService<LegalFormDTO>
    {
        private readonly IRepository<LegalForm> _repository;

        public LegalFormService(IUnitOfWork dataBase)
        {
            _dataBase = dataBase;
            _repository = dataBase.LegalForms;
            _converter = new LegalFormConverter(_dataBase);
        }

        public void Create(LegalFormDTO item)
        {
            Create(item, _repository);
        }

        public void Delete(uint? id)
        {
            Delete(id, _repository);
        }

        public LegalFormDTO Get(uint? id)
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

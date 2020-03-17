using BusinessLogicLayer.Converters;
using BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System.Collections.Generic;

namespace BusinessLogicLayer.Services
{
    class CompanyService : GeneralService<CompanyDTO, Company>, IService<CompanyDTO>
    {
        private readonly ICompanyRepository<Company> _repository;

        public CompanyService(IUnitOfWork dataBase)
        {
            _dataBase = dataBase;
            _repository = dataBase.Companies;
            _converter = new CompanyConverter(_dataBase);
        }

        public void Create(CompanyDTO item)
        {
            Create(item, _repository);
        }

        public void Delete(uint? id)
        {
            Delete(id, _repository);
        }

        public CompanyDTO Get(uint? id)
        {
            return Get(id, _repository);
        }

        public IEnumerable<CompanyDTO> GetAll()
        {
            return GetAll(_repository);
        }

        public void Update(CompanyDTO item)
        {
            Update(item, _repository);
        }
    }
}

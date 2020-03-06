using BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.Interfaces;
using CommonClasses;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Services
{
    class CompanyService : GeneralService<CompanyDTO, Company>, IService<CompanyDTO>
    {
        private IRepository<Company> _repository;

        public CompanyService(IUnitOfWork dataBase)
        {
            _repository = dataBase.Companies;
        }

        public void Create(CompanyDTO item)
        {
            Create(item, _repository);
        }

        public void Delete(IdType id)
        {
            Delete(id, _repository);
        }

        public CompanyDTO Get(IdType id)
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

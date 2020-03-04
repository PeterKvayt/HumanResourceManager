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
    class CompanyService : GeneralService<Company, CompanyDTO>, IService<CompanyDTO>
    {
        public CompanyService(IUnitOfWork dataBase)
        {
            _dataBase = dataBase;
        }

        public void Create(CompanyDTO item)
        {
            Create(item, _dataBase.Companies);
        }

        public void Delete(IdType id)
        {
            Delete(id, _dataBase.Companies);
        }

        public bool Exists(IdType id)
        {
            return Exists(id, _dataBase.Companies);
        }

        public CompanyDTO Get(IdType id)
        {
            return Get(id, _dataBase.Companies);
        }

        public IEnumerable<CompanyDTO> GetAll()
        {
            return GetAll(_dataBase.Companies);
        }

        public void Update(CompanyDTO item)
        {
            Update(item, _dataBase.Companies);
        }
    }
}

using CommonClasses;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using ExceptionClasses.Loggers;
using System;
using System.Collections.Generic;

namespace DataAccessLayer.Repositories
{
    class CompanyRepository : GeneralRepository<Company>, ICompanyRepository<Company>
    {

        public CompanyRepository(IHrmContext inputСontext)
        {
            _context = inputСontext.CompanyContext;
        }

        public int GetSize(Company item)
        {
            try
            {
                return _context.GetSize(item);
            }
            catch (Exception)
            {
                string EXCEPTION_MESSAGE = $"Ошибка получения размера компании в классе CompanyRepository!";

                ExceptionLogger.LogError(EXCEPTION_MESSAGE);

                throw;
            }
        }

        private ICompanyDataAccessLayer<Company> _context;

        public void Create(Company item)
        {
            Create(item, _context);
        }

        public void Delete(Company item)
        {
            Delete(item, _context);
        }

        public bool Exists(Company item)
        {
            return Exists(item, _context);
        }

        public Company Get(Company item)
        {
            return Get(item, _context);
        }

        public IEnumerable<Company> GetAll()
        {
            return GetAll(_context);
        }

        public void Update(Company item)
        {
            Update(item, _context);
        }
    }
}

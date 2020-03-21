using CommonClasses;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using ExceptionClasses.Logers;
using System;
using System.Collections.Generic;

namespace DataAccessLayer.Repositories
{
    class CompanyRepository : GeneralRepository<Company>, ICompanyRepository<Company>
    {
        private ICompanyDataAccessLayer<Company> _context;

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
            catch (Exception exception)
            {
                ExceptionLoger.Log(exception);

                throw;
            }
        }

        public void Create(Company item)
        {
            Create(item, _context);
        }

        public void Delete(IdType id)
        {
            Delete(id, _context);
        }

        public bool Exists(IdType id)
        {
            return Exists(id, _context);
        }

        public Company Get(IdType id)
        {
            return Get(id, _context);
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

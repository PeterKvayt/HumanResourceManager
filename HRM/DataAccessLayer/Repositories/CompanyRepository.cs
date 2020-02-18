using DataAccessLayer.Classes;
using DataAccessLayer.DataContext;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Repositories
{
    class CompanyRepository : IRepository<Company>
    {
        private readonly HRMContext context;

        public CompanyRepository(HRMContext inputСontext)
        {
            context = inputСontext;
        }

        public void Create(Company item)
        {
            throw new NotImplementedException();
        }

        public void Delete(IdType id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Company> Find(Func<Company, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Company Get(IdType id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Company> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Company item)
        {
            throw new NotImplementedException();
        }
    }
}

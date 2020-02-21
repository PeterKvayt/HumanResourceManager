using DataAccessLayer.AssistantClasses;
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
        private readonly IDataAccessLayer<Company> context;

        public CompanyRepository(HRMContext inputСontext)
        {
            context = inputСontext.CompanyContext;
        }

        public void Create(Company newCompany)
        {
            context.Create(newCompany);
        }

        public void Delete(IdType id)
        {
            context.Delete(id);
        }

        public Company Get(IdType id)
        {
            return context.Get(id);
        }

        public IEnumerable<Company> GetAll()
        {
            return context.GetAll();
        }

        public void Update(Company item)
        {
            context.Update(item);
        }

        public IEnumerable<Company> Find(Func<Company, bool> predicate)
        {
            // ToDo: find
            throw new NotImplementedException();
        }
    }
}

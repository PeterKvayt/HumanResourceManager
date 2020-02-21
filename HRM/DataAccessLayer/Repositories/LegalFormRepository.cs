using DataAccessLayer.AssistantClasses;
using DataAccessLayer.DataContext;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Repositories
{
    class LegalFormRepository : IRepository<LegalForm>
    {
        private readonly IDataAccessLayer<LegalForm> context;

        public LegalFormRepository(HRMContext inputСontext)
        {
            context = inputСontext.LegalFormContext;
        }

        public void Create(LegalForm newLegalForm)
        {
            context.Create(newLegalForm);
        }

        public void Delete(IdType id)
        {
            context.Delete(id);
        }

        public LegalForm Get(IdType id)
        {
            return context.Get(id);
        }

        public IEnumerable<LegalForm> GetAll()
        {
            return context.GetAll();
        }

        public void Update(LegalForm item)
        {
            context.Update(item);
        }

        public IEnumerable<LegalForm> Find(Func<LegalForm, bool> predicate)
        {
            // ToDo: find
            throw new NotImplementedException();
        }
    }
}

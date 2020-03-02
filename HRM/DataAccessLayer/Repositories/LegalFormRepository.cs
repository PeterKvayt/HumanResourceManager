using CommonClasses;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System.Collections.Generic;

namespace DataAccessLayer.Repositories
{
    class LegalFormRepository : GeneralRepository<LegalForm>, IRepository<LegalForm>
    {
        private IDataAccessLayer<LegalForm> _context;

        public LegalFormRepository(IHrmContext inputСontext)
        {
            _context = inputСontext.LegalFormContext;
        }

        public void Create(LegalForm item)
        {
            Create(item, _context);
        }

        public void Delete(LegalForm item)
        {
            Delete(item, _context);
        }

        public bool Exists(LegalForm item)
        {
            return Exists(item, _context);
        }

        public LegalForm Get(LegalForm item)
        {
            return Get(item, _context);
        }

        public IEnumerable<LegalForm> GetAll()
        {
            return GetAll(_context);
        }

        public void Update(LegalForm item)
        {
            Update(item, _context);
        }
    }
}

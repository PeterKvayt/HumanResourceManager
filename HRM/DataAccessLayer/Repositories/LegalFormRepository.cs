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

        public void Delete(IdType id)
        {
            Delete(id, _context);
        }

        public bool Exists(IdType id)
        {
            return Exists(id, _context);
        }

        public LegalForm Get(IdType id)
        {
            return Get(id, _context);
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

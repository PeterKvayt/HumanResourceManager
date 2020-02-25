using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;

namespace DataAccessLayer.Repositories
{
    class LegalFormRepository : GeneralRepository<LegalForm>, IRepository<LegalForm>
    {
        public LegalFormRepository(IHrmContext inputСontext)
        {
            context = inputСontext.LegalFormContext;
        }
    }
}

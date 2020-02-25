using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;

namespace DataAccessLayer.Repositories
{
    class CompanyRepository : GeneralRepository<Company>, IRepository<Company>
    {
        public CompanyRepository(IHrmContext inputСontext)
        {
            context = inputСontext.CompanyContext;
        }
    }
}

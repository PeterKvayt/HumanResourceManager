using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;

namespace DataAccessLayer.Repositories
{
    class EmployeeRepository : GeneralRepository<Employee>, IRepository<Employee>
    {
        public EmployeeRepository(IHrmContext inputСontext)
        {
            _context = inputСontext.EmployeeContext;
        }
    }
}

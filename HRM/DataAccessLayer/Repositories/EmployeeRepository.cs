using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;

namespace DataAccessLayer.Repositories
{
    class EmployeeRepository : GeneralRepository<Employee>, IRepository<Employee>
    {
        public EmployeeRepository(IHrmContext inputСontext)
        {
            context = inputСontext.EmployeeContext;
        }
    }
}

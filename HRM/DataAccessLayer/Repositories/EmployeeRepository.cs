using CommonClasses;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System.Collections.Generic;

namespace DataAccessLayer.Repositories
{
    class EmployeeRepository : GeneralRepository<Employee>, IRepository<Employee>
    {
        private IDataAccessLayer<Employee> _context;

        public EmployeeRepository(IHrmContext inputСontext)
        {
            _context = inputСontext.EmployeeContext;
        }

        public void Create(Employee item)
        {
            Create(item, _context);
        }

        public void Delete(Employee item)
        {
            Delete(item, _context);
        }

        public bool Exists(Employee item)
        {
            return Exists(item, _context);
        }

        public Employee Get(Employee item)
        {
            return Get(item, _context);
        }

        public IEnumerable<Employee> GetAll()
        {
            return GetAll(_context);
        }

        public void Update(Employee item)
        {
            Update(item, _context);
        }
    }
}

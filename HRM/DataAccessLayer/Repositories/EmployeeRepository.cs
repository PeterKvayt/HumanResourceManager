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

        public void Delete(IdType id)
        {
            Delete(id, _context);
        }

        public bool Exists(IdType id)
        {
            return Exists(id, _context);
        }

        public Employee Get(IdType id)
        {
            return Get(id, _context);
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

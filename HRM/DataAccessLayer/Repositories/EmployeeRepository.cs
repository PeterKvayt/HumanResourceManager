using DataAccessLayer.Classes;
using DataAccessLayer.DataContext;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Repositories
{
    class EmployeeRepository : IRepository<Employee>
    {
        private readonly HRMContext context;

        public EmployeeRepository(HRMContext inputСontext)
        {
            context = inputСontext;
        }
        
        public void Create(Employee item)
        {
            throw new NotImplementedException();
        }

        public void Delete(IdType id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> Find(Func<Employee, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Employee Get(IdType id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Employee item)
        {
            throw new NotImplementedException();
        }
    }
}

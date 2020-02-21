using DataAccessLayer.AssistantClasses;
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
        private readonly IDataAccessLayer<Employee> context;

        public EmployeeRepository(HRMContext inputСontext)
        {
            context = inputСontext.EmployeeContext;
        }
        
        public void Create(Employee newEmployee)
        {
            context.Create(newEmployee);
        }

        public void Delete(IdType id)
        {
            context.Delete(id);
        }

        public Employee Get(IdType id)
        {
            return context.Get(id);
        }

        public IEnumerable<Employee> GetAll()
        {
            return context.GetAll();
        }

        public void Update(Employee item)
        {
            context.Update(item);
        }

        public IEnumerable<Employee> Find(Func<Employee, bool> predicate)
        {
            // ToDo : find
            throw new NotImplementedException();
        }
    }
}

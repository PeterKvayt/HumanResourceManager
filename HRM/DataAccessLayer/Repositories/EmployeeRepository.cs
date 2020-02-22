using DataAccessLayer.AssistantClasses;
using DataAccessLayer.DataContext;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Repositories
{
    class EmployeeRepository : GeneralRepository<Employee>, IRepository<Employee>
    {
        public EmployeeRepository(IHRMContext inputСontext)
        {
            context = inputСontext.EmployeeContext;
        }
    }
}

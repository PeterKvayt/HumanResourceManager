using DataAccessLayer.AssistantClasses;
using DataAccessLayer.DataContext;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

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

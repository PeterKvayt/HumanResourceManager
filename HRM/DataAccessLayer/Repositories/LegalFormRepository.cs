using DataAccessLayer.AssistantClasses;
using DataAccessLayer.DataContext;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

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

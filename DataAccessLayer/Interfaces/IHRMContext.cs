using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Interfaces
{
    interface IHRMContext
    {
        IDataAccessLayer<Company> CompanyContext { get; }

        IDataAccessLayer<Employee> EmployeeContext { get; }

        IDataAccessLayer<LegalForm> LegalFormContext { get; }

        IDataAccessLayer<Position> PositionContext { get; }

        IDataAccessLayer<ActivityType> ActivityTypeContext { get; }
    }
}

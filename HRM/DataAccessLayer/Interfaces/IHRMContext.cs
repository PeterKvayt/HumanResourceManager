using DataAccessLayer.Entities;

namespace DataAccessLayer.Interfaces
{
    interface IHrmContext
    {
        ICompanyDataAccessLayer<Company> CompanyContext { get; }

        IDataAccessLayer<Employee> EmployeeContext { get; }

        IDataAccessLayer<LegalForm> LegalFormContext { get; }

        IDataAccessLayer<Position> PositionContext { get; }

        IDataAccessLayer<ActivityType> ActivityTypeContext { get; }
    }
}

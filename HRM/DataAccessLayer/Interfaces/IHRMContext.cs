using DataAccessLayer.Entities;

namespace DataAccessLayer.Interfaces
{
    interface IHrmContext
    {
        IDataAccessLayer<Company> CompanyContext { get; }

        IDataAccessLayer<Employee> EmployeeContext { get; }

        IDataAccessLayer<LegalForm> LegalFormContext { get; }

        IDataAccessLayer<Position> PositionContext { get; }

        IDataAccessLayer<ActivityType> ActivityTypeContext { get; }
    }
}

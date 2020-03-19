using DataAccessLayer.Entities;

namespace DataAccessLayer.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Employee> Employees { get; }

        ICompanyRepository<Company> Companies { get; }

        IRepository<Position> Positions { get; }

        IRepository<LegalForm> LegalForms { get; }

        IRepository<ActivityType> ActivityTypes { get; }
    }
}

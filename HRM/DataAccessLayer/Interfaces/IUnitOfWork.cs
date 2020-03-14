using DataAccessLayer.Entities;
using System;

namespace DataAccessLayer.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Employee> Employees { get; }

        ICompanyRepository<Company> Companies { get; }

        IRepository<Position> Positions { get; }

        IRepository<LegalForm> LegalForms { get; }

        IRepository<ActivityType> ActivityTypes { get; }

        void Save();
    }
}

using DataAccessLayer.Entities;
using System;

namespace DataAccessLayer.Interfaces
{
    interface IUnitOfWork : IDisposable
    {
        IRepository<Employee> Employees { get; }

        IRepository<Company> Companies { get; }

        IRepository<Position> Positions { get; }

        IRepository<LegalForm> LegalForms { get; }

        IRepository<ActivityType> ActivityTypes { get; }

        void Save();
    }
}

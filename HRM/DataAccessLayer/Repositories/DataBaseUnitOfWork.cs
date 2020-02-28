using DataAccessLayer.DataContext;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;

namespace DataAccessLayer.Repositories
{
    /// <summary>
    /// Класс, инкапсулирующий взаимодействие с уровнем доступа к базе данных
    /// </summary>
    class DataBaseUnitOfWork : IUnitOfWork
    {
        private readonly IHrmContext _context;

        public DataBaseUnitOfWork()
        {
            _context = new HrmContext();
        }

        private EmployeeRepository _employeeRepository;
        public IRepository<Employee> Employees
        {
            get
            {
                if (_employeeRepository == null)
                {
                    _employeeRepository = new EmployeeRepository(_context);
                }
                return _employeeRepository;
            }
        }

        private CompanyRepository _companyRepository;
        public IRepository<Company> Companies
        {
            get
            {
                if (_companyRepository == null)
                {
                    _companyRepository = new CompanyRepository(_context);
                }
                return _companyRepository;
            }
        }

        private PositionRepository _positionRepository;
        public IRepository<Position> Positions
        {
            get
            {
                if (_positionRepository == null)
                {
                    _positionRepository = new PositionRepository(_context);
                }
                return _positionRepository;
            }
        }

        private LegalFormRepository _legalFormRepository;
        public IRepository<LegalForm> LegalForms
        {
            get
            {
                if (_legalFormRepository == null)
                {
                    _legalFormRepository = new LegalFormRepository(_context);
                }
                return _legalFormRepository;
            }
        }

        private ActivityTypeRepository _activityTypeRepository;
        public IRepository<ActivityType> ActivityTypes
        {
            get
            {
                if (_activityTypeRepository == null)
                {
                    _activityTypeRepository = new ActivityTypeRepository(_context);
                }
                return _activityTypeRepository;
            }
        }

        public void Save()
        {
            // ToDo: context.SaveChanges()
        }

        #region IDisposable Support
        private bool disposedValue = false; // Для определения избыточных вызовов

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // ToDo: context.Dispose()
                }

                disposedValue = true;
            }
        }

        // TODO: переопределить метод завершения, только если Dispose(bool disposing) выше включает код для освобождения неуправляемых ресурсов.
        // ~DataBaseUnitOfWork() {
        //   // Не изменяйте этот код. Разместите код очистки выше, в методе Dispose(bool disposing).
        //   Dispose(false);
        // }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}

using DataAccessLayer.DataContext;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Repositories
{
    class DataBaseUnitOfWork : IUnitOfWork
    {
        private readonly HRMContext context;

        public DataBaseUnitOfWork()
        {
            context = new HRMContext();
        }

        private EmployeeRepository employeeRepository;
        public IRepository<Employee> Employees
        {
            get
            {
                if (employeeRepository == null)
                {
                    employeeRepository = new EmployeeRepository(context);
                }
                return employeeRepository;
            }
        }

        private CompanyRepository companyRepository;
        public IRepository<Company> Companies
        {
            get
            {
                if (companyRepository == null)
                {
                    companyRepository = new CompanyRepository(context);
                }
                return companyRepository;
            }
        }

        private PositionRepository positionRepository;
        public IRepository<Position> Positions
        {
            get
            {
                if (positionRepository == null)
                {
                    positionRepository = new PositionRepository(context);
                }
                return positionRepository;
            }
        }

        private LegalFormRepository legalFormRepository;
        public IRepository<LegalForm> LegalForms
        {
            get
            {
                if (legalFormRepository == null)
                {
                    legalFormRepository = new LegalFormRepository(context);
                }
                return legalFormRepository;
            }
        }

        private ActivityTypeRepository activityTypeRepository;
        public IRepository<ActivityType> ActivityTypes
        {
            get
            {
                if (activityTypeRepository == null)
                {
                    activityTypeRepository = new ActivityTypeRepository(context);
                }
                return activityTypeRepository;
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

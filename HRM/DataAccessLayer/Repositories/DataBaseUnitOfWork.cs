using DataAccessLayer.DataContext;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using ExceptionClasses.Loggers;
using System;

namespace DataAccessLayer.Repositories
{
    /// <summary>
    /// Класс, инкапсулирующий взаимодействие с уровнем доступа к базе данных
    /// </summary>
    public class DataBaseUnitOfWork : IUnitOfWork
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
        public ICompanyRepository<Company> Companies
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
    }
}

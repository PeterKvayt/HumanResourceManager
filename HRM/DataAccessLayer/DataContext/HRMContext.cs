using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using ExceptionClasses.Loggers;
using System;
using System.Data.SqlClient;

namespace DataAccessLayer.DataContext
{
    /// <summary>
    /// Класс отвечает за контекст данных
    /// </summary>
    class HrmContext : IHrmContext
    {
        public HrmContext()
        {
        }

        private CompanyDataAccessLayer _companyContext;
        public ICompanyDataAccessLayer<Company> CompanyContext
        {
            get
            {
                if (_companyContext == null)
                {
                    _companyContext = new CompanyDataAccessLayer();
                }
                return _companyContext;
            }
        }

        private EmployeeDataAccessLayer _employeeContext;
        public IDataAccessLayer<Employee> EmployeeContext
        {
            get
            {
                if (_employeeContext == null)
                {
                    _employeeContext = new EmployeeDataAccessLayer();
                }
                return _employeeContext;
            }
        }

        private LegalFormDataAccessLayer _legalFormContext;
        public IDataAccessLayer<LegalForm> LegalFormContext
        {
            get
            {
                if (_legalFormContext == null)
                {
                    _legalFormContext = new LegalFormDataAccessLayer();
                }
                return _legalFormContext;
            }
        }

        private PositionDataAccessLayer _positionContext;
        public IDataAccessLayer<Position> PositionContext
        {
            get
            {
                if (_positionContext == null)
                {
                    _positionContext = new PositionDataAccessLayer();
                }
                return _positionContext;
            }
        }

        private ActivityTypeDataAccessLayer _activityTypeContext;
        public IDataAccessLayer<ActivityType> ActivityTypeContext
        {
            get
            {
                if (_activityTypeContext == null)
                {
                    _activityTypeContext = new ActivityTypeDataAccessLayer();
                }
                return _activityTypeContext;
            }
        }
    }
}

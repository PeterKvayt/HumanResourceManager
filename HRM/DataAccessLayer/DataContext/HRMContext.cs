using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DataAccessLayer.DataContext
{
    class HrmContext : IHrmContext
    {
        private readonly SqlConnection connection;

        public HrmContext()
        {
            connection = new SqlConnection();
        }

        private CompanyDataAccessLayer companyContext;
        public IDataAccessLayer<Company> CompanyContext
        {
            get
            {
                if (companyContext == null)
                {
                    companyContext = new CompanyDataAccessLayer();
                }
                return companyContext;
            }
        }

        private EmployeeDataAccessLayer employeeContext;
        public IDataAccessLayer<Employee> EmployeeContext
        {
            get
            {
                if (employeeContext == null)
                {
                    employeeContext = new EmployeeDataAccessLayer();
                }
                return employeeContext;
            }
        }

        private LegalFormDataAccessLayer legalFormContext;
        public IDataAccessLayer<LegalForm> LegalFormContext
        {
            get
            {
                if (legalFormContext == null)
                {
                    legalFormContext = new LegalFormDataAccessLayer();
                }
                return legalFormContext;
            }
        }

        private PositionDataAccessLayer positionContext;
        public IDataAccessLayer<Position> PositionContext
        {
            get
            {
                if (positionContext == null)
                {
                    positionContext = new PositionDataAccessLayer();
                }
                return positionContext;
            }
        }

        private ActivityTypeDataAccessLayer activityTypeContext;
        public IDataAccessLayer<ActivityType> ActivityTypeContext
        {
            get
            {
                if (activityTypeContext == null)
                {
                    activityTypeContext = new ActivityTypeDataAccessLayer();
                }
                return activityTypeContext;
            }
        }
    }
}

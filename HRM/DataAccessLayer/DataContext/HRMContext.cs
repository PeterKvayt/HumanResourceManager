using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DataAccessLayer.DataContext
{
    class HRMContext : IHRMContext
    {
        private readonly SqlConnection connection;

        public HRMContext()
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
        public IDataAccessLayer<Employee> EmployeeContext => throw new NotImplementedException();

        private LegalForm legalFormContext;
        public IDataAccessLayer<LegalForm> LegalFormContext => throw new NotImplementedException();

        private PositionDataAccessLayer positionContext;
        public IDataAccessLayer<Position> PositionContext => throw new NotImplementedException();

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

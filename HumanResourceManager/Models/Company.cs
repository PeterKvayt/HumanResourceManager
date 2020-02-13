using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanResourceManager.Models
{
    public class Company
    {
        private CompanyData m_CompanyData;

        public OrganizationalType OrganizationalType { get; set; }

        public ActivityType ActivityType { get; set; }

        public Company(CompanyData companyData, OrganizationalType organizationalType, ActivityType activityType)
        {
            m_CompanyData = companyData;

            OrganizationalType = organizationalType;

            ActivityType = activityType;
        }

        public Company() { }

        public int GetId()
        {
            return m_CompanyData.Id;
        }

        public string GetName()
        {
            return m_CompanyData.Name;
        }

        public int? GetSize()
        {
            return m_CompanyData.Size;
        }
    }
}

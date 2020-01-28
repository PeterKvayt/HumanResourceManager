using HumanResourceManager.Models;
using System.Collections.Generic;

namespace HumanResourceManager.ViewModels
{

    public class CompanyViewModel
    {
        public List<OrganizationalType> OrganizationalTypes { get; set; }

        public List<ActivityType> ActivityTypes { get; set; }

        public Company Company { get; set; }

        public string OrganizationalTypeParams { get; set; }

        public string ActivityTypeParams { get; set; }

        public CompanyViewModel(List<OrganizationalType> organizationalTypes, List<ActivityType> activityTypes, Company company)
        {
            OrganizationalTypes = organizationalTypes;
            ActivityTypes = activityTypes;
            Company = company;
        }

    }
}

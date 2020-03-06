using BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Mapper;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;

namespace BusinessLogicLayer.Converters
{
    class CompanyConverter : GeneralConverter<Company, CompanyDTO>, IConverter<Company, CompanyDTO>
    {
        public CompanyConverter(IUnitOfWork dataBase)
        {
            _dataBase = dataBase;
        }

        public override Company Convert(CompanyDTO companyDTO)
        {
            Company company = new Company
            {
                Id = companyDTO.Id,
                ActivityId = companyDTO.ActivityType.Id,
                LegalFormId = companyDTO.LegalForm.Id,
                Name = companyDTO.Name
            };

            return company;
        }

        public override CompanyDTO Convert(Company company)
        {
            var activityType = _dataBase.ActivityTypes.Get(company.ActivityId);
            var activityTypeDTO = AutoMapper<ActivityTypeDTO>.Map(activityType);

            var legalForm = _dataBase.LegalForms.Get(company.LegalFormId);
            var legalFormDTO = AutoMapper<LegalFormDTO>.Map(legalForm);

            CompanyDTO companyDTO = new CompanyDTO
            {
                Id = company.Id,
                ActivityType = activityTypeDTO,
                LegalForm = legalFormDTO,
                Name = company.Name
            };

            return companyDTO;
        }
    }
}

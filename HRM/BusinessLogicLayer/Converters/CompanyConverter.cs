using BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.Interfaces;
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
                ActivityTypeId = companyDTO.ActivityType.Id,
                LegalFormId = companyDTO.LegalForm.Id,
                Name = companyDTO.Name
            };

            return company;
        }

        public override CompanyDTO Convert(Company company)
        {
            var activityType = _dataBase.ActivityTypes.Get(company.ActivityTypeId);
            var activityTypeDTO = TryMap<ActivityTypeDTO, ActivityType>(activityType);

            var legalForm = _dataBase.LegalForms.Get(company.LegalFormId);
            var legalFormDTO = TryMap<LegalFormDTO, LegalForm>(legalForm);

            int size = _dataBase.Companies.GetSize(company);

            CompanyDTO companyDTO = new CompanyDTO
            {
                Id = company.Id,
                ActivityType = activityTypeDTO,
                LegalForm = legalFormDTO,
                Name = company.Name,
                Size = size
            };

            return companyDTO;
        }
    }
}

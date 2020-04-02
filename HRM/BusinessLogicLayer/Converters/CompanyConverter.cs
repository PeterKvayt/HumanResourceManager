using BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;

namespace BusinessLogicLayer.Converters
{
    class CompanyConverter : GeneralConverter<Company, CompanyDTO>, IConverter<Company, CompanyDTO>
    {
        private readonly IConverter<ActivityType, ActivityTypeDTO> _activityTypeConverter;

        private readonly IConverter<LegalForm, LegalFormDTO> _legalFormConverter;

        public CompanyConverter(IUnitOfWork dataBase, IConverter<ActivityType, ActivityTypeDTO> activityTypeConverter, IConverter<LegalForm, LegalFormDTO> legalFormConverter)
        {
            _dataBase = dataBase;

            _activityTypeConverter = activityTypeConverter;

            _legalFormConverter = legalFormConverter;
        }

        public Company Convert(CompanyDTO companyDTO)
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

        public CompanyDTO Convert(Company company)
        {
            var activityType = _dataBase.ActivityTypes.Get(company.ActivityTypeId);
            var activityTypeDTO = _activityTypeConverter.Convert(activityType);

            var legalForm = _dataBase.LegalForms.Get(company.LegalFormId);
            var legalFormDTO = _legalFormConverter.Convert(legalForm);

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

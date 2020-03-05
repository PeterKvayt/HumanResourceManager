using BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Mapper;
using BusinessLogicLayer.PresentationLayerModels;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Converters
{
    class CompanyConverter : GeneralConverter<CompanyDTO, CompanyPLM>, IConverter<CompanyDTO, CompanyPLM>
    {
        public CompanyConverter(IUnitOfWork dataBase)
        {
            _dataBase = dataBase;
        }

        public override CompanyDTO Convert(CompanyPLM companyPLM)
        {
            CompanyDTO companyDTO = new CompanyDTO
            {
                Id = companyPLM.Id,
                ActivityId = companyPLM.ActivityType.Id,
                LegalFormId = companyPLM.LegalForm.Id,
                Name = companyPLM.Name
            };

            return companyDTO;
        }

        public override CompanyPLM Convert(CompanyDTO companyDTO)
        {
            var activityType = _dataBase.ActivityTypes.Get(companyDTO.ActivityId);
            var activityTypeDTO = AutoMapper<ActivityTypeDTO>.Map(activityType);

            var legalForm = _dataBase.LegalForms.Get(companyDTO.LegalFormId);
            var legalFormDTO = AutoMapper<LegalFormDTO>.Map(legalForm);

            CompanyPLM companyPLM = new CompanyPLM
            {
                Id = companyDTO.Id,
                ActivityType = activityTypeDTO,
                LegalForm = legalFormDTO,
                Name = companyDTO.Name
            };

            return companyPLM;
        }
    }
}

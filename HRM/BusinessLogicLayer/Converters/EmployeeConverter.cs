using BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Mapper;
using BusinessLogicLayer.PresentationLayerModels;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Converters
{
    class EmployeeConverter : GeneralConverter<EmployeeDTO, EmployeePLM>, IConverter<EmployeeDTO, EmployeePLM>
    {
        public EmployeeConverter(IUnitOfWork dataBase)
        {
            _dataBase = dataBase;
        }

        public override EmployeeDTO Convert(EmployeePLM employeePLM)
        {
            EmployeeDTO employeeDTO = new EmployeeDTO
            {
                Id = employeePLM.Id,
                Name = employeePLM.Name,
                Surname = employeePLM.Surname,
                MiddleName = employeePLM.MiddleName,
                PositionId = employeePLM.Position.Id,
                CompanyId = employeePLM.Company.Id,
                DateOfEmployment = employeePLM.DateOfEmployment
            };

            return employeeDTO;
        }

        public override EmployeePLM Convert(EmployeeDTO employeeDTO)
        {
            var position = _dataBase.Positions.Get(employeeDTO.PositionId);
            var positionDTO = AutoMapper<PositionDTO>.Map(position);

            var company = _dataBase.Companies.Get(employeeDTO.CompanyId);
            var companyDTO = AutoMapper<CompanyDTO>.Map(company);

            EmployeePLM employeePLM = new EmployeePLM
            {
                Id = employeeDTO.Id,
                Name = employeeDTO.Name,
                Surname = employeeDTO.Surname,
                MiddleName = employeeDTO.MiddleName,
                Position = positionDTO,
                Company = companyDTO
            };

            return employeePLM;
        }
    }
}

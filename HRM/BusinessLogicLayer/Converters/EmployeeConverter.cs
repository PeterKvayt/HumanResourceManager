using BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Mapper;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Converters
{
    class EmployeeConverter : GeneralConverter<Employee, EmployeeDTO>, IConverter<Employee, EmployeeDTO>
    {
        public EmployeeConverter(IUnitOfWork dataBase)
        {
            _dataBase = dataBase;
        }

        public override Employee Convert(EmployeeDTO employeeDTO)
        {
            Employee employee = new Employee
            {
                Id = employeeDTO.Id,
                Name = employeeDTO.Name,
                Surname = employeeDTO.Surname,
                MiddleName = employeeDTO.MiddleName,
                PositionId = employeeDTO.Position.Id,
                CompanyId = employeeDTO.Company.Id,
                DateOfEmployment = employeeDTO.DateOfEmployment
            };

            return employee;
        }

        public override EmployeeDTO Convert(Employee employee)
        {
            var position = _dataBase.Positions.Get(employee.PositionId);
            var positionDTO = TryMap<PositionDTO, Position>(position);

            var company = _dataBase.Companies.Get(employee.CompanyId);
            var companyDTO = TryMap<CompanyDTO, Company>(company);

            EmployeeDTO employeeDTO = new EmployeeDTO
            {
                Id = employee.Id,
                Name = employee.Name,
                Surname = employee.Surname,
                MiddleName = employee.MiddleName,
                Position = positionDTO,
                Company = companyDTO
            };

            return employeeDTO;
        }
    }
}

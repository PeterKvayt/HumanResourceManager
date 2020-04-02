using BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Converters
{
    class EmployeeConverter : GeneralConverter<Employee, EmployeeDTO>, IConverter<Employee, EmployeeDTO>
    {
        private readonly IConverter<Position, PositionDTO> _positionConverter;

        private readonly IConverter<Company, CompanyDTO> _companyConverter;

        public EmployeeConverter(IUnitOfWork dataBase, IConverter<Position, PositionDTO> positionConverter, IConverter<Company, CompanyDTO> companyConverter)
        {
            _dataBase = dataBase;

            _positionConverter = positionConverter;

            _companyConverter = companyConverter;
        }

        public Employee Convert(EmployeeDTO employeeDTO)
        {
            var employee = new Employee
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

        public EmployeeDTO Convert(Employee employee)
        {
            Position position = _dataBase.Positions.Get(employee.PositionId);
            PositionDTO positionDTO = _positionConverter.Convert(position);

            Company company = _dataBase.Companies.Get(employee.CompanyId);
            CompanyDTO companyDTO = _companyConverter.Convert(company);

            var employeeDTO = new EmployeeDTO
            {
                Id = employee.Id,
                Name = employee.Name,
                Surname = employee.Surname,
                MiddleName = employee.MiddleName,
                Position = positionDTO,
                Company = companyDTO,
                DateOfEmployment = employee.DateOfEmployment
            };

            return employeeDTO;
        }
    }
}

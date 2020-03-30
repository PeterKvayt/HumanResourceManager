using BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System.Collections.Generic;

namespace BusinessLogicLayer.Services
{
    class EmployeeService : GeneralService<EmployeeDTO, Employee>, IService<EmployeeDTO>
    {
        private readonly IRepository<Employee> _repository;

        public EmployeeService(IUnitOfWork dataBase, IConverter<Employee, EmployeeDTO> converter)
        {
            _dataBase = dataBase;
            _repository = dataBase.Employees;
            _converter = converter;
        }

        public void Create(EmployeeDTO item)
        {
            Create(item, _repository);
        }

        public void Delete(uint? id)
        {
            Delete(id, _repository);
        }

        public EmployeeDTO Get(uint? id)
        {
            return Get(id, _repository);
        }

        public IEnumerable<EmployeeDTO> GetAll()
        {
            return GetAll(_repository);
        }

        public void Update(EmployeeDTO item)
        {
            Update(item, _repository);
        }
    }
}

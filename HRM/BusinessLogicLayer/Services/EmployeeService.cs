using BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.Interfaces;
using CommonClasses;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System.Collections.Generic;

namespace BusinessLogicLayer.Services
{
    class EmployeeService : GeneralService<Employee, EmployeeDTO>, IService<EmployeeDTO>
    {
        private IRepository<Employee> _repository;

        public EmployeeService(IUnitOfWork dataBase)
        {
            _repository = dataBase.Employees;
        }

        public void Create(EmployeeDTO item)
        {
            Create(item, _repository);
        }

        public void Delete(IdType id)
        {
            Delete(id, _repository);
        }

        public bool Exists(IdType id)
        {
            return Exists(id, _repository);
        }

        public EmployeeDTO Get(IdType id)
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

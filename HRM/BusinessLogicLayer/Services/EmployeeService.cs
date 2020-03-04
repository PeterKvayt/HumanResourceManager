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
        public EmployeeService(IUnitOfWork dataBase)
        {
            _dataBase = dataBase;
        }

        public void Create(EmployeeDTO item)
        {
            Create(item, _dataBase.Employees);
        }

        public void Delete(IdType id)
        {
            Delete(id, _dataBase.Employees);
        }

        public bool Exists(IdType id)
        {
            return Exists(id, _dataBase.Employees);
        }

        public EmployeeDTO Get(IdType id)
        {
            return Get(id, _dataBase.Employees);
        }

        public IEnumerable<EmployeeDTO> GetAll()
        {
            return GetAll(_dataBase.Employees);
        }

        public void Update(EmployeeDTO item)
        {
            Update(item, _dataBase.Employees);
        }
    }
}

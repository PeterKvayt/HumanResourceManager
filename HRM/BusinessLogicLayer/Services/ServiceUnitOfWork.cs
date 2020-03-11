using BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;

namespace BusinessLogicLayer.Services
{
    public class ServiceUnitOfWork : IServiceUnitOfWork
    {
        private readonly IUnitOfWork _dataBase;

        public ServiceUnitOfWork(string connectionString)
        {
            _dataBase = new DataBaseUnitOfWork(connectionString);
        }

        private ActivityTypeService _activityTypeService;
        public IService<ActivityTypeDTO> AcivityTypeService
        {
            get
            {
                if (_activityTypeService == null)
                {
                    _activityTypeService = new ActivityTypeService(_dataBase);
                }
                return _activityTypeService;
            }
        }

        private CompanyService _companyService;
        public IService<CompanyDTO> CompanyService
        {
            get
            {
                if (_companyService == null)
                {
                    _companyService = new CompanyService(_dataBase);
                }
                return _companyService;
            }
        }

        private EmployeeService _employeeService;
        public IService<EmployeeDTO> EmployeeService
        {
            get
            {
                if (_employeeService == null)
                {
                    _employeeService = new EmployeeService(_dataBase);
                }
                return _employeeService;
            }
        }

        private LegalFormService _legalFormService;
        public IService<LegalFormDTO> LegalFormService
        {
            get
            {
                if (_legalFormService == null)
                {
                    _legalFormService = new LegalFormService(_dataBase);
                }
                return _legalFormService;
            }
        }

        private PositionService _positionService;
        public IService<PositionDTO> PositionService
        {
            get
            {
                if (_positionService == null)
                {
                    _positionService = new PositionService(_dataBase);
                }
                return _positionService;
            }
        }
    }
}

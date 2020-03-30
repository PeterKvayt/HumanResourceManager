using BusinessLogicLayer.Converters;
using BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;

namespace BusinessLogicLayer.Services
{
    /// <summary>
    /// Поставляет сервисы для WebAPI
    /// </summary>
    public class ServiceProvider : IServiceProvider
    {
        /// <summary>
        /// Предоставляет доступ к данным для сервисов
        /// </summary>
        private readonly IUnitOfWork _dataBase;

        public ServiceProvider()
        {
            _dataBase = new DataBaseUnitOfWork();
        }

        private ActivityTypeConverter _activityTypeConverter;
        private ActivityTypeService _activityTypeService;
        public IService<ActivityTypeDTO> AcivityTypeService
        {
            get
            {
                if (_activityTypeService == null)
                {
                    _activityTypeConverter = new ActivityTypeConverter(_dataBase);
                    _activityTypeService = new ActivityTypeService(_dataBase, _activityTypeConverter);
                }
                return _activityTypeService;
            }
        }

        private CompanyConverter _companyConverter;
        private CompanyService _companyService;
        public IService<CompanyDTO> CompanyService
        {
            get
            {
                if (_companyService == null)
                {
                    _companyConverter = new CompanyConverter(_dataBase);
                    _companyService = new CompanyService(_dataBase, _companyConverter);
                }
                return _companyService;
            }
        }

        private EmployeeConverter _employeeConverter;
        private EmployeeService _employeeService;
        public IService<EmployeeDTO> EmployeeService
        {
            get
            {
                if (_employeeService == null)
                {
                    _employeeConverter = new EmployeeConverter(_dataBase);
                    _employeeService = new EmployeeService(_dataBase, _employeeConverter);
                }
                return _employeeService;
            }
        }

        private LegalFormConverter _legalFormConverter;
        private LegalFormService _legalFormService;
        public IService<LegalFormDTO> LegalFormService
        {
            get
            {
                if (_legalFormService == null)
                {
                    _legalFormConverter = new LegalFormConverter(_dataBase);
                    _legalFormService = new LegalFormService(_dataBase, _legalFormConverter);
                }
                return _legalFormService;
            }
        }

        private PositionConverter _positionConverter;
        private PositionService _positionService;
        public IService<PositionDTO> PositionService
        {
            get
            {
                if (_positionService == null)
                {
                    _positionConverter = new PositionConverter(_dataBase);
                    _positionService = new PositionService(_dataBase, _positionConverter);
                }
                return _positionService;
            }
        }
    }
}

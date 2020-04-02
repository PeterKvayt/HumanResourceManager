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

        private ActivityTypeConverter _activityTypeConverter;

        private CompanyConverter _companyConverter;

        private EmployeeConverter _employeeConverter;

        private LegalFormConverter _legalFormConverter;

        private PositionConverter _positionConverter;

        public ServiceProvider()
        {
            _dataBase = new DataBaseUnitOfWork();

            _activityTypeConverter = new ActivityTypeConverter(_dataBase);

            _legalFormConverter = new LegalFormConverter(_dataBase);

            _positionConverter = new PositionConverter(_dataBase);

            _companyConverter = new CompanyConverter(_dataBase, _activityTypeConverter, _legalFormConverter);

            _employeeConverter = new EmployeeConverter(_dataBase, _positionConverter, _companyConverter);

        }

        private ActivityTypeService _activityTypeService;
        public IService<ActivityTypeDTO> AcivityTypeService
        {
            get
            {
                if (_activityTypeService == null)
                {
                    _activityTypeService = new ActivityTypeService(_dataBase, _activityTypeConverter);
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
                    _companyService = new CompanyService(_dataBase, _companyConverter);
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
                    _employeeService = new EmployeeService(_dataBase, _employeeConverter);
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
                    _legalFormService = new LegalFormService(_dataBase, _legalFormConverter);
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
                    _positionService = new PositionService(_dataBase, _positionConverter);
                }
                return _positionService;
            }
        }
    }
}

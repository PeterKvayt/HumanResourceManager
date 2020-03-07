using BusinessLogicLayer.DataTransferObjects;

namespace BusinessLogicLayer.Interfaces
{
    interface IServiceUnitOfWork
    {
        IService<ActivityTypeDTO> AcivityTypeService { get; }

        IService<CompanyDTO> CompanyService { get; }

        IService<EmployeeDTO> EmployeeService { get; }

        IService<LegalFormDTO> LegalFormService { get; }

        IService<PositionDTO> PositionService { get; }
    }
}

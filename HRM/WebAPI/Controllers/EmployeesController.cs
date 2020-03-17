using System.Collections.Generic;
using BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : GeneralController<EmployeeDTO>
    {
        private IService<EmployeeDTO> _service;

        public EmployeesController(IServiceUnitOfWork serviceProvider)
        {
            _service = serviceProvider.EmployeeService;
        }

        [HttpGet]
        public IEnumerable<EmployeeDTO> GetAll()
        {
            return GetAll(_service);
        }

        [HttpGet("{id}")]
        public EmployeeDTO Get(uint? id)
        {
            return Get(id, _service);
        }

        [HttpPost]
        public void Create(EmployeeDTO model)
        {
            Create(model, _service);
        }

        [HttpPut]
        public void Update(EmployeeDTO model)
        {
            Update(model, _service);
        }

        [HttpDelete("{id}")]
        public void Delete(uint? id)
        {
            Delete(id, _service);
        }
    }
}

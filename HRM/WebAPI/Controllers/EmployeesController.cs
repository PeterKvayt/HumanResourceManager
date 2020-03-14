using System.Collections.Generic;
using BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.Interfaces;
using CommonClasses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IService<EmployeeDTO> _service;

        public EmployeesController(IServiceUnitOfWork serviceProvider)
        {
            _service = serviceProvider.EmployeeService;
        }

        [HttpGet]
        public IEnumerable<EmployeeDTO> GetAll()
        {
            return _service.GetAll();
        }

        [HttpGet("{id}")]
        public EmployeeDTO Get(uint id)
        {
            IdType idEntity = new IdType
            {
                Identificator = id
            };

            return _service.Get(idEntity);
        }

        [HttpPost]
        public void Create(EmployeeDTO model)
        {
            EmployeeDTO positionDTO = model;

            _service.Create(positionDTO);
        }

        [HttpPut]
        public void Update(EmployeeDTO model)
        {
            _service.Update(model);
        }

        [HttpDelete("{id}")]
        public void Delete(uint id)
        {
            IdType idEntity = new IdType
            {
                Identificator = id
            };
            _service.Delete(idEntity);
        }
    }
}

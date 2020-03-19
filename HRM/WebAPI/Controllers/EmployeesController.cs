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
        public EmployeesController(IServiceProvider serviceProvider)
        {
            _service = serviceProvider.EmployeeService;
        }

        [HttpGet]
        public IEnumerable<EmployeeDTO> GetAll()
        {
            return GetAllItems();
        }

        [HttpGet("{id}")]
        public EmployeeDTO Get(uint? id)
        {
            return GetItem(id);
        }

        [HttpPost]
        public void Create(EmployeeDTO model)
        {
            CreateItem(model);
        }

        [HttpPut]
        public void Update(EmployeeDTO model)
        {
            UpdateItem(model);
        }

        [HttpDelete("{id}")]
        public void Delete(uint? id)
        {
            DeleteItem(id);
        }
    }
}

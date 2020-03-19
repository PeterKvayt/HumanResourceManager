using System.Collections.Generic;
using BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : GeneralController<CompanyDTO>
    {
        public CompaniesController(IServiceProvider serviceProvider)
        {
            _service = serviceProvider.CompanyService;
        }

        [HttpGet]
        public IEnumerable<CompanyDTO> GetAll()
        {
            return GetAllItems();
        }

        [HttpGet("{id}")]
        public CompanyDTO Get(uint? id)
        {
            return GetItem(id);
        }

        [HttpPost]
        public void Create(CompanyDTO model)
        {
            CreateItem(model);
        }

        [HttpPut]
        public void Update(CompanyDTO model)
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

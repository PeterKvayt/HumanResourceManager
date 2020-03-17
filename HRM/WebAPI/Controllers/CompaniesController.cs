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
        private IService<CompanyDTO> _service;

        public CompaniesController(IServiceUnitOfWork serviceProvider)
        {
            _service = serviceProvider.CompanyService;
        }

        [HttpGet]
        public IEnumerable<CompanyDTO> GetAll()
        {
            return GetAll(_service);
        }

        [HttpGet("{id}")]
        public CompanyDTO Get(uint? id)
        {
            return Get(id, _service);
        }

        [HttpPost]
        public void Create(CompanyDTO model)
        {
            Create(model, _service);
        }

        [HttpPut]
        public void Update(CompanyDTO model)
        {
            _service.Update(model);
        }

        [HttpDelete("{id}")]
        public void Delete(uint? id)
        {
            Delete(id, _service);
        }
    }
}

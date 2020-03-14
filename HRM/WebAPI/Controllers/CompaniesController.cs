using System.Collections.Generic;
using BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.Interfaces;
using CommonClasses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private IService<CompanyDTO> _service;

        public CompaniesController(IServiceUnitOfWork serviceProvider)
        {
            _service = serviceProvider.CompanyService;
        }

        [HttpGet]
        public IEnumerable<CompanyDTO> GetAll()
        {
            return _service.GetAll();
        }

        [HttpGet("{id}")]
        public CompanyDTO Get(uint id)
        {
            IdType idEntity = new IdType
            {
                Identificator = id
            };

            return _service.Get(idEntity);
        }

        [HttpPost]
        public void Create(CompanyDTO model)
        {
            CompanyDTO positionDTO = model;

            _service.Create(positionDTO);
        }

        [HttpPut]
        public void Update(CompanyDTO model)
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

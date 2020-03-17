using System.Collections.Generic;
using BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LegalFormsController : GeneralController<LegalFormDTO>
    {
        private IService<LegalFormDTO> _service;

        public LegalFormsController(IServiceUnitOfWork serviceProvider)
        {
            _service = serviceProvider.LegalFormService;
        }

        [HttpGet]
        public IEnumerable<LegalFormDTO> GetAll()
        {
            return GetAll(_service);
        }

        [HttpGet("{id}")]
        public LegalFormDTO Get(uint? id)
        {
            return Get(id, _service);
        }

        [HttpPost]
        public void Create(LegalFormDTO model)
        {
            Create(model, _service);
        }

        [HttpPut]
        public void Update(LegalFormDTO model)
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

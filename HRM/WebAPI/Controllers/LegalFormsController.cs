using System.Collections.Generic;
using BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.Interfaces;
using CommonClasses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LegalFormsController : ControllerBase
    {
        private IService<LegalFormDTO> _service;

        public LegalFormsController(IServiceUnitOfWork serviceProvider)
        {
            _service = serviceProvider.LegalFormService;
        }

        [HttpGet]
        public IEnumerable<LegalFormDTO> GetAll()
        {
            return _service.GetAll();
        }

        [HttpGet("{id}")]
        public LegalFormDTO Get(uint id)
        {
            IdType idEntity = new IdType
            {
                Identificator = id
            };

            return _service.Get(idEntity);
        }

        [HttpPost]
        public void Create(LegalFormDTO model)
        {
            LegalFormDTO positionDTO = model;

            _service.Create(positionDTO);
        }

        [HttpPut]
        public void Update(LegalFormDTO model)
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

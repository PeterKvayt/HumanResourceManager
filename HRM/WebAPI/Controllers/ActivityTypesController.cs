using System.Collections.Generic;
using BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.Interfaces;
using CommonClasses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityTypesController : ControllerBase
    {
        private IService<ActivityTypeDTO> _service;

        public ActivityTypesController(IServiceUnitOfWork serviceProvider)
        {
            _service = serviceProvider.AcivityTypeService;
        }

        [HttpGet]
        public IEnumerable<ActivityTypeDTO> GetAll()
        {
            return _service.GetAll();
        }

        [HttpGet("{id}")]
        public ActivityTypeDTO Get(uint id)
        {
            IdType idEntity = new IdType
            {
                Identificator = id
            };

            return _service.Get(idEntity);
        }

        [HttpPost]
        public void Create(ActivityTypeDTO model)
        {
            ActivityTypeDTO positionDTO = model;

            _service.Create(positionDTO);
        }

        [HttpPut]
        public void Update(ActivityTypeDTO model)
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

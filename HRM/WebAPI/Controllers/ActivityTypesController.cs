using System.Collections.Generic;
using BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityTypesController : GeneralController<ActivityTypeDTO>
    {
        private IService<ActivityTypeDTO> _service;

        public ActivityTypesController(IServiceUnitOfWork serviceProvider)
        {
            _service = serviceProvider.AcivityTypeService;
        }

        [HttpGet]
        public IEnumerable<ActivityTypeDTO> GetAll()
        {
            return GetAll(_service);
        }

        [HttpGet("{id}")]
        public ActivityTypeDTO Get(uint? id)
        {
            return Get(id, _service);
        }

        [HttpPost]
        public void Create(ActivityTypeDTO model)
        {
            Create(model, _service);
        }

        [HttpPut]
        public void Update(ActivityTypeDTO model)
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

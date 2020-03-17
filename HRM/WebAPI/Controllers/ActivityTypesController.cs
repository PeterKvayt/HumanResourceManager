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
        public ActivityTypesController(IServiceUnitOfWork serviceProvider)
        {
            _service = serviceProvider.AcivityTypeService;
        }

        [HttpGet]
        public IEnumerable<ActivityTypeDTO> GetAll()
        {
            return GetAllItems();
        }

        [HttpGet("{id}")]
        public ActivityTypeDTO Get(uint? id)
        {
            return GetItem(id);
        }

        [HttpPost]
        public void Create(ActivityTypeDTO model)
        {
            CreateItem(model);
        }

        [HttpPut]
        public void Update(ActivityTypeDTO model)
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

using System.Collections.Generic;
using BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionsController : GeneralController<PositionDTO>
    {
        public PositionsController(IServiceProvider serviceProvider)
        {
            _service = serviceProvider.PositionService;
        }

        [HttpGet]
        public IEnumerable<PositionDTO> GetAll()
        {
            return GetAllItems();
        }

        [HttpGet("{id}")]
        public PositionDTO Get(uint? id)
        {
            return GetItem(id);
        }

        [HttpPost]
        public void Create(PositionDTO model)
        {
            CreateItem(model);
        }

        [HttpPut]
        public void Update(PositionDTO model)
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

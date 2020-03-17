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
        private IService<PositionDTO> _service;

        public PositionsController(IServiceUnitOfWork serviceProvider)
        {
            _service = serviceProvider.PositionService;
        }

        [HttpGet]
        public IEnumerable<PositionDTO> GetAll()
        {
            return GetAll(_service);
        }

        [HttpGet("{id}")]
        public PositionDTO Get(uint? id)
        {
            return Get(id, _service);
        }

        [HttpPost]
        public void Create(PositionDTO model)
        {
            Create(model, _service);
        }

        [HttpPut]
        public void Update(PositionDTO model)
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

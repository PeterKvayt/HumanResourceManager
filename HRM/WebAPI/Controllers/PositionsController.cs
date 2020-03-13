using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.Interfaces;
using CommonClasses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionsController : ControllerBase
    {
        private IService<PositionDTO> _service;

        public PositionsController(IServiceUnitOfWork serviceProvider)
        {
            _service = serviceProvider.PositionService;
        }

        [HttpGet]
        public IEnumerable<PositionDTO> GetAll()
        {
            return _service.GetAll();
        }

        //[HttpGet("{id}")]
        //public PositionDTO Update(uint id)
        //{
        //    IdType idEntity = new IdType
        //    {
        //        Identificator = id
        //    };

        //    return _service.Get(idEntity);
        //}

        [HttpPost("{model}")]
        public void Create(PositionDTO model)
        {
            _service.Create(model);
        }

        [HttpPut("{model}")]
        public void Update([FromBody] PositionDTO model)
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

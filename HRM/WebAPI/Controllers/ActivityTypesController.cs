using System;
using System.Collections.Generic;
using System.Net;
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
        public ActivityTypeDTO Get(uint? id)
        {
            if (id == null)
            {
                throw new HttpListenerException(404);
            }

            IdType idEntity = new IdType
            {
                Identificator = (uint)id
            };

            return _service.Get(idEntity);
        }

        [HttpPost]
        public void Create(ActivityTypeDTO model)
        {
            _service.Create(model);
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

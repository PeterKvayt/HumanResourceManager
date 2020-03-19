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
        public LegalFormsController(IServiceProvider serviceProvider)
        {
            _service = serviceProvider.LegalFormService;
        }

        [HttpGet]
        public IEnumerable<LegalFormDTO> GetAll()
        {
            return GetAllItems();
        }

        [HttpGet("{id}")]
        public LegalFormDTO Get(uint? id)
        {
            return GetItem(id);
        }

        [HttpPost]
        public void Create(LegalFormDTO model)
        {
            CreateItem(model);
        }

        [HttpPut]
        public void Update(LegalFormDTO model)
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

using Ebtdaa.Application.FactoryLocations.Dtos;
using Ebtdaa.Application.InspectionProductData.Dtos;
using Ebtdaa.Application.InspectionProductData.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ebtdaa.WebApi.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class InspectProductAttachmentsController : ControllerBase
    {
        private readonly IInspectProductDataAttachService _service;

        public InspectProductAttachmentsController(IInspectProductDataAttachService service)
        {
            _service = service;
        }

        // GET api/<InspectProductAttachmentsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAll(int id)
        {
            return Ok(await _service.GetAll(id));

        }

        // POST api/<InspectProductAttachmentsController>
        [HttpPost]
        public async Task<IActionResult> CreateAsync(InspectProductAttachReqDto request)
        {
            return Ok(await _service.AddAsync(request));
        }
        [HttpGet("ProductsFiles")]
        public async Task<IActionResult> GetAllFiles(int factoryId)
        {
            return Ok(await _service.GetAllFiles(factoryId));

        }

    }
}

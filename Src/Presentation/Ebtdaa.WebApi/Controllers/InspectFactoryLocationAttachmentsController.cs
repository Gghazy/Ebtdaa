using Ebtdaa.Application.InspectionFactoryLocation.Dtos;
using Ebtdaa.Application.InspectionFactoryLocation.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ebtdaa.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InspectFactoryLocationAttachmentsController : ControllerBase
    {
        private readonly IInspectFactoryLocationAttachService _service;

        public InspectFactoryLocationAttachmentsController(IInspectFactoryLocationAttachService service)
        {
            _service = service;
        }

        [HttpGet("{id}")] 
        public async Task<IActionResult> GetAll(int id)
        {
            return Ok(await _service.GetAll(id));

        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(InspectFactoryLocationAttachReqDto request)
        {
            return Ok(await _service.AddAsync(request));
        }

    }
}

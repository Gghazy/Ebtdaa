
using Ebtdaa.Application.FactoryLocations.Dtos;
using Ebtdaa.Application.FactoryLocations.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ebtdaa.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FactoryLocationAttachmentsController : ControllerBase
    {
        private readonly IFactoryLocationAttachmentService _service;

        public FactoryLocationAttachmentsController(IFactoryLocationAttachmentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAll());

        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(FactoryLocationAttachmentRequestDto request)
        {
            return Ok(await _service.AddAsync(request));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            return Ok(await _service.DeleteAsync(id));

        }
    }
}

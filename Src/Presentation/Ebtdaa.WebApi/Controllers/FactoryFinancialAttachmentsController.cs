using Ebtdaa.Application.Factories.Dtos;
using Ebtdaa.Application.Factories.Interfaces;
using Ebtdaa.Application.FactoryFinancials.Dtos;
using Ebtdaa.Application.FactoryFinancials.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ebtdaa.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FactoryFinancialAttachmentsController : ControllerBase
    {
        private readonly IFactoryFinancialAttachmentService _service;

        public FactoryFinancialAttachmentsController(IFactoryFinancialAttachmentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAll());

        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(FactoryFinancialAttachmentRequestDto request)
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

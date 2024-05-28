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
        public async Task<IActionResult> GetAll(int Factoryid, int PeriodId)
        {
            return Ok(await _service.GetAll(Factoryid,PeriodId));

        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(FactoryFinancialAttachmentRequestDto request)
        {
            return Ok(await _service.AddAsync(request));
        }

        [HttpPut]
        public async Task<IActionResult> Update(FactoryFinancialAttachmentRequestDto request)
        {
            return Ok(await _service.UpdateAsync(request));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            return Ok(await _service.DeleteAsync(id));

        }
    }
}

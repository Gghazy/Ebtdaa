using Ebtdaa.Application.ActualProduction.Dtos;
using Ebtdaa.Application.ActualProduction.Interfaces;
using Ebtdaa.Application.FactoryFinancials.Dtos;
using Microsoft.AspNetCore.Mvc;


namespace Ebtdaa.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActualProductionAttachmentsController : ControllerBase
    {
        private readonly IActualProductionAttachService _service;

        public ActualProductionAttachmentsController(IActualProductionAttachService service)
        {
            _service = service;
        }


        // GET: api/<ActualProductionAttachmentsController>
        [HttpGet(":id")]
        public async Task<IActionResult> GetAll(int factoryId)
        {
            return Ok(await _service.GetAll(factoryId));

        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(ActualProductionAttacRequestDto request)
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

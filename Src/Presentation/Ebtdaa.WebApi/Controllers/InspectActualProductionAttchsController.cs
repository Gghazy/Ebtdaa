using Ebtdaa.Application.InspectionActualProduction.Dtos;
using Ebtdaa.Application.InspectionActualProduction.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace Ebtdaa.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InspectActualProductionAttchsController : ControllerBase
    {
        private readonly IInspectActualProductionAttachService _service;

        public InspectActualProductionAttchsController(IInspectActualProductionAttachService service)
        {
            _service = service;
        }


        // GET: api/<InspectActualProductionAttchsController>
        [HttpGet]
        public async Task<IActionResult> GetAll(int factoryId, int periodId)
        {
            return Ok(await _service.GetAll(factoryId, periodId));

        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] InspectActualProductionAttachReqDto request)
        {
            return Ok(await _service.AddAsync(request));
        }

    }
}

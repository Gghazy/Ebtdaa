using Ebtdaa.Application.InspectionActualProduction.Dtos;
using Ebtdaa.Application.InspectionActualProduction.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace Ebtdaa.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InspectActualProductionsController : ControllerBase
    {
        private readonly IInspectActualProductionService _actualProductionService;

        public InspectActualProductionsController(IInspectActualProductionService actualProductionService)
        {
            _actualProductionService = actualProductionService;
        }
       
        // GET api/<InspectActualProductionssController>/5
        [HttpGet]
        public async Task<IActionResult> GetAll(int factoryId , int periodId)
        {
            return Ok( await _actualProductionService.GetAll(factoryId , periodId));
        }

        // POST api/<InspectActualProductionssController>
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] InspectActualProductionReqDto req)
        {
            return Ok(await _actualProductionService.AddAsync(req));
        }

        // PUT api/<InspectActualProductionssController>/5
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] InspectActualProductionReqDto req)
        {
            return Ok(await _actualProductionService.UpdateAsync(req));
        }

        
    }
}

using Ebtdaa.Application.Factories.Dtos;
using Ebtdaa.Application.InspectionBasicFactInfos.Dtos;
using Ebtdaa.Application.InspectionBasicFactInfos.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace Ebtdaa.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InspectBaiscDatasController : ControllerBase
    {
        private readonly IInspectBasicFactInfoService _inspectBasicFactInfoService;
        public InspectBaiscDatasController(IInspectBasicFactInfoService inspectBasicFactInfoService)
        {
            _inspectBasicFactInfoService = inspectBasicFactInfoService;
        }

        // GET: api/<InspectBaiscDatasController>
        [HttpGet]
        public async Task<IActionResult> GetOne(int factoryId, int periodId, string ownerIdentity)
        {
            return Ok(await _inspectBasicFactInfoService.GetOne(factoryId, periodId, ownerIdentity));

        }

        // GET api/<InspectBaiscDatasController>/5
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] InspectBasicFactInfoRequestDto req)
        {
            return Ok(await _inspectBasicFactInfoService.UpdateAsync(req));
        }

        // POST api/<InspectBaiscDatasController>
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] InspectBasicFactInfoRequestDto req)
        {
            return Ok(await _inspectBasicFactInfoService.AddAsync(req));
        }
    }
}

using Ebtdaa.Application.ActualProduction.Dtos;
using Ebtdaa.Application.ActualProduction.Interfaces;
using Ebtdaa.Common.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Ebtdaa.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncreaseActualProductionsController : ControllerBase
    {
        private readonly IIncreaseActualProductionService _increaseActualProductionService;
        public IncreaseActualProductionsController(IIncreaseActualProductionService increaseActualProductionService)
        {
            _increaseActualProductionService = increaseActualProductionService;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(MonthsEnum id)
        {
            return Ok(await _increaseActualProductionService.GetOne(id));

        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] IncreaseActualProductionRequestDto req)
        {

            return Ok(await _increaseActualProductionService.AddAsync(req));

        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] IncreaseActualProductionRequestDto req)
        {

            return Ok(await _increaseActualProductionService.UpdateAsync(req));

        }
    }
}

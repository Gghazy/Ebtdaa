using Ebtdaa.Application.FactoryFinancials.Dtos;
using Ebtdaa.Application.FactoryFinancials.Interfaces;
using Ebtdaa.Application.FactoryLocations.Dtos;
using Ebtdaa.Application.FactoryLocations.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ebtdaa.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FactoryLocationsController : ControllerBase
    {
        private readonly IFactoryLocationService _factoryLocationService;
        public FactoryLocationsController(IFactoryLocationService factoryLocationService)
        {
            _factoryLocationService = factoryLocationService;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int factoryId, int periodId)
        {
            return Ok(await _factoryLocationService.GetOne(factoryId , periodId));

        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] FactoryLocationRequestDto req)
        {

            return Ok(await _factoryLocationService.AddAsync(req));

        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] FactoryLocationRequestDto req)
        {

            return Ok(await _factoryLocationService.UpdateAsync(req));

        }
    }
}

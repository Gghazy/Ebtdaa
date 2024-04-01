using Ebtdaa.Application.InspectionFactoryLocation.Dtos;
using Ebtdaa.Application.InspectionFactoryLocation.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ebtdaa.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InspectFactoryLocationsController : ControllerBase
    {
        private readonly IInspectFactoryLocationService _InspectFactoryLocationservice;
        public InspectFactoryLocationsController(IInspectFactoryLocationService InspectFactoryLocationservice)
        {
            _InspectFactoryLocationservice = InspectFactoryLocationservice;
        }


        [HttpGet]
        public async Task<IActionResult> GetOne(int factoryId)
        {
            return Ok(await _InspectFactoryLocationservice.GetOne(factoryId));

        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] InspectFactoryLocationReqDto req)
        {

            return Ok(await _InspectFactoryLocationservice.AddAsync(req));

        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] InspectFactoryLocationReqDto req)
        {

            return Ok(await _InspectFactoryLocationservice.UpdateAsync(req));

        }
    }
}

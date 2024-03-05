using Ebtdaa.Application.FactoriesUpdateStatus.Dtos;
using Ebtdaa.Application.FactoriesUpdateStatus.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ebtdaa.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FactoryUpdateStatusesController : ControllerBase
    {
        private readonly IFactoryUpdateStatusService _FactoryUpdateStatus;
        public FactoryUpdateStatusesController(IFactoryUpdateStatusService factoryUpdateStatus)
        {
            _FactoryUpdateStatus = factoryUpdateStatus;
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] FactUpdateStatusRequestDto req)
        {

            return Ok(await _FactoryUpdateStatus.AddAsync(req));

        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] FactUpdateStatusRequestDto req)
        {

            return Ok(await _FactoryUpdateStatus.UpdateAsync(req));

        }
    }
}

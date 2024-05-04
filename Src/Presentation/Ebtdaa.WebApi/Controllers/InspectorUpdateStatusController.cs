using Ebtdaa.Application.FactoriesUpdateStatus.Dtos;
using Ebtdaa.Application.FactoriesUpdateStatus.Interfaces;
using Ebtdaa.Application.InspectorUpdateStatus.Dtos;
using Ebtdaa.Application.InspectorUpdateStatus.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ebtdaa.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InspectorUpdateStatusController : ControllerBase
    {
        private readonly IInspectorUpdateStatusService _UpdateStatus;
        public InspectorUpdateStatusController(IInspectorUpdateStatusService UpdateStatus)
        {
            _UpdateStatus = UpdateStatus;
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] InspectorUpdateStatusRequestDto req)
        {

            return Ok(await _UpdateStatus.AddAsync(req));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] InspectorUpdateStatusRequestDto req)
        {

            return Ok(await _UpdateStatus.UpdateAsync(req));

        }

        [HttpGet]
        public async Task<IActionResult> GetOne(int factoryId, int periodId)
        {
            return Ok(await _UpdateStatus.GetOne(factoryId, periodId));

        }
    }
}

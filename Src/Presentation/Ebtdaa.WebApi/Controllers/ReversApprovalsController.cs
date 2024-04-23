using Ebtdaa.Application.ReverseApproval.Dtos;
using Ebtdaa.Application.ReverseApproval.Interfaces;
using Ebtdaa.Application.ScreenUpdateStatus.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ebtdaa.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReversApprovalsController : ControllerBase
    {
        private readonly IReverseApprovalService _reversApproval;
        public ReversApprovalsController(IReverseApprovalService reversApproval)
        {
            _reversApproval = reversApproval;
        }


        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] ReverseApprovalRequestDto req)
        {
            return Ok(await _reversApproval.UpdateAsync(req));

        }
    }
}

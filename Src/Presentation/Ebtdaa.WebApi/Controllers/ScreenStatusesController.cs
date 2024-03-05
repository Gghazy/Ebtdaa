using Ebtdaa.Application.ScreenUpdateStatus.Dtos;
using Ebtdaa.Application.ScreenUpdateStatus.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ebtdaa.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScreenStatusesController : ControllerBase
    {
        private readonly IScreenStatusService _screenStatusService;
        public ScreenStatusesController(IScreenStatusService screenStatusService)
        {
            _screenStatusService = screenStatusService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll(int factoryId, int periodId)
        {
            return Ok(await _screenStatusService.GetAll(factoryId, periodId));

        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] ScreenStatusRequestDto req)
        {

            return Ok(await _screenStatusService.AddAsync(req));

        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] ScreenStatusRequestDto req)
        {

            return Ok(await _screenStatusService.UpdateAsync(req));

        }
    }
}

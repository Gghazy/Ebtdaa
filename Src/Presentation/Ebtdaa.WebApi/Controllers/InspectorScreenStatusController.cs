using Ebtdaa.Application.InspectorScreenStatus.Interfaces;
using Ebtdaa.Application.ScreenUpdateStatus.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ebtdaa.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InspectorScreenStatusController : ControllerBase
    {
        private readonly IInspectorScreenStatusService _screenStatusService;
        public InspectorScreenStatusController(IInspectorScreenStatusService screenStatusService)
        {
            _screenStatusService = screenStatusService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll(int factoryId, int periodId)
        {
            return Ok(await _screenStatusService.GetAll(periodId, factoryId));

        }
    }
}

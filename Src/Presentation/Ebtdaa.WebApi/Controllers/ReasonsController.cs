using Ebtdaa.Application.ActualProduction.Interfaces;
using Ebtdaa.Application.Cities.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ebtdaa.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReasonsController : ControllerBase
    {
        private readonly IReasonService _reasonService;
        public ReasonsController(IReasonService reasonService)
        {
            _reasonService = reasonService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _reasonService.GetAll());
        }
    }
}

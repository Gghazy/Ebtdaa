using Ebtdaa.Application.Cities.Interfaces;
using Ebtdaa.Application.Periods.Dtos;
using Ebtdaa.Application.Periods.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ebtdaa.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeriodsController : ControllerBase
    {
        private readonly IPeriodService _periodService;
        public PeriodsController(IPeriodService periodService)
        {
            _periodService = periodService;
        }

        [HttpPost]
        public async Task<IActionResult> GetAll(PeriodSearch search)
        {
            return Ok(await _periodService.GetAll(search));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            return Ok(await _periodService.GetOne(id));

        }
    }
}

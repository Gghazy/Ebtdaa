using Ebtdaa.Application.Cities.Interfaces;
using Ebtdaa.Domain.Factories.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ebtdaa.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ICityService _cityService;
        public CitiesController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _cityService.GetAll());
        }

        [HttpGet("ByEntity")]
        public async Task<IActionResult> GetByEntity(int id)
        {
            return Ok(await _cityService.GetByEntity( id));
        }
    }
}

using Ebtdaa.Application.IndustrialAreas.Interfaces;
using Ebtdaa.Domain.Factories.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ebtdaa.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndustrialAreasController : ControllerBase
    {
        private readonly IIndustrialAreaService _industrialArea;
        public IndustrialAreasController(IIndustrialAreaService industrialArea)
        {
            _industrialArea = industrialArea;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _industrialArea.GetAll());
        }
    }
}

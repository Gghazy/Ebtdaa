using Ebtdaa.Application.Cities.Interfaces;
using Ebtdaa.Application.FactoryEntities.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ebtdaa.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FactoryEntitiesController : ControllerBase
    {
        private readonly IFactoryEntityService _factoryEntityService;
        public FactoryEntitiesController(IFactoryEntityService factoryEntityService)
        {
            _factoryEntityService = factoryEntityService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _factoryEntityService.GetAll());
        }

    }
}

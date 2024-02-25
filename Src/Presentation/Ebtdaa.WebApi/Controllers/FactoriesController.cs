using Ebtdaa.Application.Factories.Dtos;
using Ebtdaa.Application.Factories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ebtdaa.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FactoriesController : ControllerBase
    {
        private readonly IFactoryService _factoryService;
        public FactoriesController(IFactoryService factoryService)
        {
            _factoryService = factoryService;
        }

        [HttpPost]
        public async Task<IActionResult> GetAll([FromBody]FactorySearch search)
        {
            return Ok(await _factoryService.GetAll(search));

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id , int periodId)
        {
            return Ok(await _factoryService.GetOne(id, periodId));

        } 

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] FactoryRequestDto req)
        {

            return Ok(await _factoryService.UpdateAsync(req));

        }
    }
}

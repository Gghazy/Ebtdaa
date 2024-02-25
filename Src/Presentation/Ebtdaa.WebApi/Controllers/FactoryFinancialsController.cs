using Ebtdaa.Application.Factories.Dtos;
using Ebtdaa.Application.FactoryFinancials.Dtos;
using Ebtdaa.Application.FactoryFinancials.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ebtdaa.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FactoryFinancialsController : ControllerBase
    {
        private readonly IFactoryFinancialService _factoryFinancialService;
        public FactoryFinancialsController(IFactoryFinancialService factoryFinancialService)
        {
            _factoryFinancialService = factoryFinancialService;
        }


        [HttpGet]
        public async Task<IActionResult> GetOne(int id,int year)
        {
            return Ok(await _factoryFinancialService.GetOne(id, year));

        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] FactoryFinancialRequestDto req)
        {

            return Ok(await _factoryFinancialService.AddAsync(req));

        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] FactoryFinancialRequestDto req)
        {

            return Ok(await _factoryFinancialService.UpdateAsync(req));

        }
    }
}

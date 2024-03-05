using Ebtdaa.Application.FactoryFinancials.Dtos;
using Ebtdaa.Application.FactoryFinancials.Interfaces;
using Ebtdaa.Application.FactoryMonthlyFinancials.Dtos;
using Ebtdaa.Application.FactoryMonthlyFinancials.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ebtdaa.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FactoryMonthlyFinancialsController : ControllerBase
    {
        private readonly IFactoryMonthlyFinancialService _service;
        public FactoryMonthlyFinancialsController(IFactoryMonthlyFinancialService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<IActionResult> GetOne(int id, int periodId)
        {
            return Ok(await _service.GetOne(id, periodId));

        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] FactoryMonthlyFinancialRequestDto req)
        {

            return Ok(await _service.AddAsync(req));

        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] FactoryMonthlyFinancialRequestDto req)
        {

            return Ok(await _service.UpdateAsync(req));

        }
    }
}

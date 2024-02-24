using Ebtdaa.Application.FactoryContacts.Dtos;
using Ebtdaa.Application.FactoryContacts.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ebtdaa.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FactoryContactsController : ControllerBase
    {
        private readonly IFactoryContactService _FactoryContactService;
        public FactoryContactsController(IFactoryContactService FactoryContactService)
        {
            _FactoryContactService = FactoryContactService;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int factoryId, int periodId)
        {
            return Ok(await _FactoryContactService.GetOne(factoryId , periodId));

        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] FactoryContactRequestDto req)
        {

            return Ok(await _FactoryContactService.AddAsync(req));

        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] FactoryContactRequestDto req)
        {

            return Ok(await _FactoryContactService.UpdateAsync(req));

        }
    }
}

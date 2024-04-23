using Ebtdaa.Application.InspectionFactoryContact.Dtos;
using Ebtdaa.Application.InspectionFactoryContact.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ebtdaa.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InspectFactoryContactController : ControllerBase
    {
        private readonly IInspectFactoryContactService _InspectFactoryContactervice;
        public InspectFactoryContactController(IInspectFactoryContactService InspectFactoryContactervice)
        {
            _InspectFactoryContactervice = InspectFactoryContactervice;
        }


        [HttpGet]
        public async Task<IActionResult> GetOne(int factoryId, int periodId, string ownerIdentity)
        {
            return Ok(await _InspectFactoryContactervice.GetOne(factoryId , periodId , ownerIdentity));

        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(InspectFactContactRequestDto req)
        {

            return Ok(await _InspectFactoryContactervice.AddAsync(req));

        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] InspectFactContactRequestDto req)
        {

            return Ok(await _InspectFactoryContactervice.UpdateAsync(req));

        }
    }
}

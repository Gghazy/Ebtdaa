using Ebtdaa.Application.IndustiryalZone.Interfaces;
using Ebtdaa.Domain.Factories.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ebtdaa.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndustiryalZoneTypesController : ControllerBase
    {
        private readonly IIndustiryalZoneTypeService _industrialZone;
        public IndustiryalZoneTypesController(IIndustiryalZoneTypeService industrialZone)
        {
            _industrialZone = industrialZone;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _industrialZone.GetAll());
        }
    }
}

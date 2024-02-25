using Ebtdaa.Application.CustomItemRawMaterials.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ebtdaa.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomItemRawMaterialController : ControllerBase
    {
        private readonly ICustomItemRawMaterialServices _customService;
        public CustomItemRawMaterialController(ICustomItemRawMaterialServices customItemRaw)
        {
            _customService = customItemRaw;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _customService.GetAll());
        }
    }
}

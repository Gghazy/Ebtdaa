using Ebtdaa.Application.ActualRawMaterials.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Ebtdaa.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SsoController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> getNationalID()
        {

            return Ok("nafath callback Result");
        }

    }
}

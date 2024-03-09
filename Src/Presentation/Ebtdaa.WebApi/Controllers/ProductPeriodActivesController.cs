using Ebtdaa.Application.ProductsData.Dtos;
using Ebtdaa.Application.ProductsData.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ebtdaa.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductPeriodActivesController : ControllerBase
    {
        private readonly IProductPeriodActiveService _periodActiveService;
        public ProductPeriodActivesController(IProductPeriodActiveService periodActiveService)
        {
            _periodActiveService = periodActiveService;
        }

        // POST api/<ProductsController>
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] List<ProductPeriodActiveRequestDto> req)
        {
            return Ok(await _periodActiveService.AddAsync(req));
        }


    }
}

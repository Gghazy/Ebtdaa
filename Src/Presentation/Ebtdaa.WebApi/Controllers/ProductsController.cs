using Ebtdaa.Application.ActualProduction.Dtos;
using Ebtdaa.Application.ProductsData.Dtos;
using Ebtdaa.Application.ProductsData.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace Ebtdaa.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductDataService _productDataService;

        public ProductsController(IProductDataService productDataService)
        {
            _productDataService = productDataService;
        }

        [HttpPost("Pagination")]
        public async Task<IActionResult> GetAll(ProductSearch search)
        {
            return Ok(await _productDataService.GetAll(search));
        }

        [HttpPost("ProductLevel10")]
        public async Task<IActionResult> ProductLevel10(ProductSearch search)
        {
            return Ok(await _productDataService.ProductLevel10(search));
        }

        // GET: api/<ProductsController>/id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            return Ok(await _productDataService.GetOne(id));
        }

        // POST api/<ProductsController>
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] ProductRequestDto req)
        {
            return Ok(await _productDataService.AddAsync(req));
        }

        // PUT api/<ProductsController>/5
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] ProductRequestDto req)
        {
            return Ok(await _productDataService.UpdateAsync(req));
        }
    }
}

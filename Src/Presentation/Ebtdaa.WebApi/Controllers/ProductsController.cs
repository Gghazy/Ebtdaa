using Ebtdaa.Application.ActualProduction.Dtos;
using Ebtdaa.Application.ProductsData.Dtos;
using Ebtdaa.Application.ProductsData.Interfaces;
using Ebtdaa.Common.Dtos;
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

        [HttpPost("AllProducts")]
        public async Task<IActionResult> GetAllProducts(SearchCriteria search)
        {
            return Ok(await _productDataService.GetAllProducts(search));
        }

        [HttpPost("getAllProductsNotInFactory")]
        public async Task<IActionResult> GetAll(ProductsNotInFactorySearch search)
        {
            return Ok(await _productDataService.getAllProductsNotInFactory(search));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(int factoryId)
        {
            return Ok(await _productDataService.GetAll(factoryId));
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

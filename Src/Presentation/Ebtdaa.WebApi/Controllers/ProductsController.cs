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
        [HttpPost("GetFactoryProduct")]
        public async Task<IActionResult> GetFactoryProduct(ProductSearch search)
        {
            return Ok(await _productDataService.GetFactoryProduct(search));
        }

        [HttpGet("AllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            return Ok(await _productDataService.GetAllProducts());
        }
        [HttpPost("AllProductsList")]
        public async Task<IActionResult> GetAllProducts(ProductSearch search)
        {
            return Ok(await _productDataService.AllProductsList(search));
        }
        [HttpPost("AllProductsLists")]
        public async Task<IActionResult> AllProductsLists(ProductPaging search)
        {
            return Ok(await _productDataService.AllProductsLists(search));
        }
        [HttpPost("GetProductsList")]
        public async Task<IActionResult> GetProductsList(ProductPaging search)
        {
            return Ok(await _productDataService.GetProductsList(search));
        }
        [HttpPost("GetAllProductsList")]
        public async Task<IActionResult> GetAllProductsList(ProductPaging search)
        {
            return Ok(await _productDataService.GetAllProductsList(search));
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

        [HttpPost("GetAddedAll")]
        public async Task<IActionResult> GetAddedAll(ProductSearch search)
        {
            return Ok(await _productDataService.GetAddedAll(search));
        }

        // GET: api/<ProductsController>/id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            return Ok(await _productDataService.GetOne(id));
        }
        [HttpGet("GetOneAddedProduct")]
        public async Task<IActionResult> GetAddProduct(int id)
        {
            return Ok(await _productDataService.GetOneAddedProduct(id));
        }

        [HttpPost("GetOneNewProduct")]
        public async Task<IActionResult> GetOneNewProduct(NewProductRequest item)
        {
            return Ok(await _productDataService.GetOneNewProduct(item));
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

using Ebtdaa.Application.InspectionProductData.Dtos;
using Ebtdaa.Application.InspectionProductData.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace Ebtdaa.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InspectProductsController : ControllerBase
    {
        private readonly IInspectProductsService _productDataService;

        public InspectProductsController(IInspectProductsService productDataService)
        {
            _productDataService = productDataService;
        }


        // GET: api/<InspectProductsController>/id
        [HttpGet]
        public async Task<IActionResult> GetProducts(int factoryId , int periodId, string ownerIdentity)
        {
            return Ok(await _productDataService.GetProducts(factoryId , periodId,ownerIdentity));
        }

        // POST api/<InspectProductsController>
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] InspectProductsRequestDto req)
        {
            return Ok(await _productDataService.AddAsync(req));
        }

        // PUT api/<InspectProductsController>/5
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] InspectProductsRequestDto req)
        {
            return Ok(await _productDataService.UpdateAsync(req));
        }
    }
}

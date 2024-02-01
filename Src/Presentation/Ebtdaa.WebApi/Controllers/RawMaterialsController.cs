using Ebtdaa.Application.RawMaterials.Dtos;
using Ebtdaa.Application.RawMaterials.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ebtdaa.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RawMaterialsController : ControllerBase
    {
        private readonly IRawMaterialService _RawMaterialService;

        public RawMaterialsController(IRawMaterialService RawMaterialService)
        {
            _RawMaterialService = RawMaterialService;
        }

        //[HttpGet]
        //public async Task<IActionResult> GetAll()
        //{
        //    return Ok(await _RawMaterialService.GetAll());

        //}


        [HttpPost("pagination")]
        public async Task<IActionResult> GetByFactory([FromBody] RawMaterialSearch search,int Factoryid)
        {
            return Ok(await _RawMaterialService.GetByFactory(search,Factoryid));

        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] RawMaterialRequestDto  request)
        {
            return Ok(await _RawMaterialService.AddAsync(request));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            return Ok(await _RawMaterialService.GetOne(id));

        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] RawMaterialRequestDto req)
        {

            return Ok(await _RawMaterialService.UpdateAsync(req));

        }
    }
}

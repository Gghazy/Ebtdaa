using Ebtdaa.Application.InspectorRawMaterials.Dtos;
using Ebtdaa.Application.InspectorRawMaterials.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ebtdaa.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InspectorRawMaterialController : ControllerBase
    {
        private readonly IInspectorRawMaterialService _InspectorRawMaterialService;

        public InspectorRawMaterialController(IInspectorRawMaterialService inspectorRawMaterialService)
        {
            _InspectorRawMaterialService = inspectorRawMaterialService;
        }

        //[HttpGet]
        //public async Task<IActionResult> GetAll()
        //{
        //    return Ok(await _RawMaterialService.GetAll());

        //}


        [HttpPost("All")]
        public async Task<IActionResult> GetByFactory( int Factoryid)
        {
            return Ok(await _InspectorRawMaterialService.GetByFactory(Factoryid));

        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] InspectorRawMaterialRequestDto request)
        {
            return Ok(await _InspectorRawMaterialService.AddAsync(request));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            return Ok(await _InspectorRawMaterialService.GetOne(id));

        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] InspectorRawMaterialRequestDto req)
        {

            return Ok(await _InspectorRawMaterialService.UpdateAsync(req));

        }
    }
}

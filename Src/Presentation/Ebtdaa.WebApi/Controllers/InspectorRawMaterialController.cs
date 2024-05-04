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

        [HttpGet]
        public async Task<IActionResult> GetAll(int factoryId, int periodId, string ownerIdentity)
        {
            return Ok(await _InspectorRawMaterialService.GetAll(factoryId,periodId,ownerIdentity));

        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(InspectorRawMaterialRequestDto request)
        {
            return Ok(await _InspectorRawMaterialService.AddAsync(request));
        }

      

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] InspectorRawMaterialRequestDto req)
        {

            return Ok(await _InspectorRawMaterialService.UpdateAsync(req));

        }
    }
}

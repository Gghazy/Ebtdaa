using Ebtdaa.Application.InspectorRawMaterials.Dtos;
using Ebtdaa.Application.InspectorRawMaterials.Handlers;
using Ebtdaa.Application.InspectorRawMaterials.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ebtdaa.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InspectorRawMaterialFileController : ControllerBase
    {
        private readonly IInspectorRawMaterialFileService _service;

        public InspectorRawMaterialFileController(IInspectorRawMaterialFileService factoryFileService)
        {
            _service = factoryFileService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int factoryId, int periodId)
        {
            return Ok(await _service.GetAll(factoryId, periodId));

        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(InspectorRawMaterialFileRequestDto request)
        {
            return Ok(await _service.AddAsync(request));
        }
    }
}

using Ebtdaa.Application.ActualRawMaterials.Dtos;
using Ebtdaa.Application.ActualRawMaterials.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ebtdaa.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActualRawMaterialFileController : ControllerBase
    {
        private readonly IActualRawFileService _actualRawMaterialFileService;

        public ActualRawMaterialFileController(IActualRawFileService actualFileService)
        {
            _actualRawMaterialFileService = actualFileService;
        }

        [HttpGet]
        public async Task<IActionResult> GetByItem(int id)
        {
            return Ok(await _actualRawMaterialFileService.GetByItem(id));

        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(ActualRawFileRequestDto request)
        {
            return Ok(await _actualRawMaterialFileService.AddAsync(request));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            return Ok(await _actualRawMaterialFileService.DeleteAsync(id));

        }
    }
}

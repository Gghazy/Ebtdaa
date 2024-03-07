using Ebtdaa.Application.Factories.Dtos;
using Ebtdaa.Application.Factories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ebtdaa.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FactoryFilesController : ControllerBase
    {
        private readonly IFactoryFileService _factoryFileService;

        public FactoryFilesController(IFactoryFileService factoryFileService )
        {
            _factoryFileService = factoryFileService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int factoryId, int periodId)
        {
            return Ok(await _factoryFileService.GetAll(factoryId,periodId));

        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(FactoryFileRequestDto request)
        {
            return Ok(await _factoryFileService.AddAsync(request));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            return Ok(await _factoryFileService.DeleteAsync(id));

        }
    }
}

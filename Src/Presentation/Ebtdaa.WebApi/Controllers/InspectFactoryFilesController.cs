using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.Factories.Dtos;
using Ebtdaa.Application.Factories.Interfaces;
using Ebtdaa.Application.InspectionBasicFactInfos.Dtos;
using Ebtdaa.Application.InspectionBasicFactInfos.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ebtdaa.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InspectFactoryFilesController : ControllerBase
    {
        private readonly IInspectFactoryFIleService _factoryFileService;

        public InspectFactoryFilesController(IInspectFactoryFIleService factoryFileService )
        {
            _factoryFileService = factoryFileService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int factoryId, int periodId)
        {
            return Ok(await _factoryFileService.GetAll(factoryId,periodId));

        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(InspectFactoryFlieRequestDto request)
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

using Ebtdaa.Application.ActualRawMaterials.Dtos;
using Ebtdaa.Application.ActualRawMaterials.Interfaces;
using Ebtdaa.Application.Factories.Dtos;
using Ebtdaa.Application.Factories.Handlers;
using Ebtdaa.Application.Factories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ebtdaa.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActualRawMaterialsController : ControllerBase
    {
        private readonly IActualRawMaterialService _actualRawMaterialService;

        public ActualRawMaterialsController(IActualRawMaterialService actualRawMaterialService)
        {
            _actualRawMaterialService = actualRawMaterialService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _actualRawMaterialService.GetAll());

        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(ActualRawMaterialRequestDto request)
        {
            return Ok(await _actualRawMaterialService.AddAsync(request));
        }

       
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            return Ok(await _actualRawMaterialService.GetOne(id));

        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] ActualRawMaterialRequestDto req)
        {

            return Ok(await _actualRawMaterialService.UpdateAsync(req));

        }
    }
}

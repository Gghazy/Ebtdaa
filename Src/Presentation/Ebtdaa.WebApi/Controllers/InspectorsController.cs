using Ebtdaa.Application.ActualRawMaterials.Dtos;
using Ebtdaa.Application.Inspectors.Dtos;
using Ebtdaa.Application.Inspectors.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace Ebtdaa.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InspectorsController : ControllerBase
    {
        private readonly IInspectorService _inspectorService;

        public InspectorsController(IInspectorService inspectorService)
        {
            _inspectorService = inspectorService;
        }

        // GET: api/<InspectorsController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _inspectorService.GetAll());

        }

        // GET api/<InspectorsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            return Ok(await _inspectorService.GetOne(id));

        }

        // POST api/<InspectorsController>
        [HttpPost]
        public async Task<IActionResult> CreateAsync(InspectorRequestDto request)
        {
            return Ok(await _inspectorService.AddAsync(request));
        }

        // PUT api/<InspectorsController>/5
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] InspectorRequestDto req)
        {

            return Ok(await _inspectorService.UpdateAsync(req));

        }

        // DELETE api/<InspectorsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            return Ok(await _inspectorService.DeleteAsync(id));
        }
    }
}

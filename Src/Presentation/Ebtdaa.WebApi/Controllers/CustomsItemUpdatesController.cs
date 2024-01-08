using Ebtdaa.Application.CustomsItemUpdateData.Dtos;
using Ebtdaa.Application.CustomsItemUpdateData.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace Ebtdaa.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomsItemUpdatesController : ControllerBase
    {
        private readonly ICustomsItemUpdateDataService _CustomsItemUpdateDataService;
        public CustomsItemUpdatesController(ICustomsItemUpdateDataService customsItemUpdateDataService)
        {
            _CustomsItemUpdateDataService = customsItemUpdateDataService;
        }
       

        // GET api/<CustomsItemUpdatesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            return Ok(await _CustomsItemUpdateDataService.GetOne(id));
        }

        // POST api/<CustomsItemUpdatesController>
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CustomsItemUpdateRequestDto req)
        {

            return Ok(await _CustomsItemUpdateDataService.AddAsync(req));
        }

        // PUT api/<CustomsItemUpdatesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(CustomsItemUpdateRequestDto req)
        {
            return Ok(await _CustomsItemUpdateDataService.UpdateAsync(req));
        }

        // DELETE api/<CustomsItemUpdatesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

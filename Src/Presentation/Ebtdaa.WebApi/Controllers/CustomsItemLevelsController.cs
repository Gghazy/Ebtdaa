using Ebtdaa.Application.CustomsItem.Dtos;
using Ebtdaa.Application.CustomsItem.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace Ebtdaa.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomsItemLevelsController : ControllerBase
    {
        private readonly ICustomsItemLevelService _CustomsItemLevelService;

        public CustomsItemLevelsController(ICustomsItemLevelService customsItemLevelService)
        {
            _CustomsItemLevelService = customsItemLevelService;
        }

        // GET: api/<CustomsItemLevelsController>
        [HttpGet]
        public async Task<IActionResult> GetAll([FromBody] CustomsItemSearch search)
        {
            return Ok(await _CustomsItemLevelService.GetAll(search));
        }

        // GET api/<CustomsItemLevelsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

       
    }
}

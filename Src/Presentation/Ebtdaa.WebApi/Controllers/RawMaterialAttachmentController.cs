using Ebtdaa.Application.RawMaterials.Dtos;
using Ebtdaa.Application.RawMaterials.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ebtdaa.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RawMaterialAttachmentController : ControllerBase
    {
        private readonly IItemAttachmentService _itemAttachmentService;

        public RawMaterialAttachmentController(IItemAttachmentService itemAttachmentService)
        {
            _itemAttachmentService = itemAttachmentService;
        }



        [HttpGet]
        public async Task<IActionResult> GetByItem(int Itemid)
        {
            return Ok(await _itemAttachmentService.GetByItem(Itemid));

        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] ItemAttachmentsRequestDto request)
        {
            return Ok(await _itemAttachmentService.AddAsync(request));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            return Ok(await _itemAttachmentService.GetOne(id));

        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] ItemAttachmentsRequestDto req)
        {

            return Ok(await _itemAttachmentService.UpdateAsync(req));

        }
    }
}

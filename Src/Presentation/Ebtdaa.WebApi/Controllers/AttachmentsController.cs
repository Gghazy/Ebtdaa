using Ebtdaa.Application.Attachments.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ebtdaa.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttachmentsController : ControllerBase
    {
        private readonly IAttachmentService _attachmentService;

        public AttachmentsController(IAttachmentService attachmentService)
        {
            _attachmentService = attachmentService;
        }


        [HttpPost]
        public async Task<IActionResult> CreateAsync()
        {
            var file = Request.Form.Files.Count > 0 ? Request.Form.Files[0] : null;
            return Ok(await _attachmentService.AddAsync(file));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> DownloadFile(int id)
        {
            var result = await _attachmentService.DownloadFile(id);

            return File(result.File, result.Extention, result.Name);
        }
    }
}

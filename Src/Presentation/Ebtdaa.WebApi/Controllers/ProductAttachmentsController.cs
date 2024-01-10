using Ebtdaa.Application.ProductsData.Dtos;
using Ebtdaa.Application.ProductsData.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace Ebtdaa.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductAttachmentsController : ControllerBase
    {
        private readonly IProductAttachmentService _productAttachmentService;

        public ProductAttachmentsController(IProductAttachmentService productAttachmentService)
        {
            _productAttachmentService = productAttachmentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _productAttachmentService.GetAll());

        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(ProductAttachmentRequestDto request)
        {
            return Ok(await _productAttachmentService.AddAsync(request));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            return Ok(await _productAttachmentService.DeleteAsync(id));

        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Api.Data;
using OnlineShop.Api.Dtos.ImageDtos;
using OnlineShop.Api.Services;

namespace OnlineShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageService service;

        public ImageController(IImageService service)
        {
            this.service = service;
        }
        [HttpGet("Image/{id}")]
        public async Task<IActionResult> GetImagesAsync([FromRoute] Guid id)
            => Ok(await service.GetImageAsync(id));

        [HttpGet("ImageProductId/{productId}")]
        public async Task<IActionResult> GetImageProductIdAsync([FromRoute] Guid productId)
            => Ok(await service.GetImageProductIdAsync(productId));

        [HttpGet("ProductImage/{productId}")]
        public async Task<IActionResult> GetProductImageAsync([FromRoute] Guid productId)
            => Ok(await service.GetProductImageAsync(productId));

        [HttpPost("SaveImage")]
        public async Task<IActionResult> SaveImageAsync([FromBody] CreateImageDto newImage)
            => Ok(await service.SaveImageAsync(newImage));
    }
}

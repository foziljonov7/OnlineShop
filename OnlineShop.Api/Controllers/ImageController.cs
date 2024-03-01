using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Api.Data;
using OnlineShop.Api.Dtos.ImageDtos;
using OnlineShop.Api.Models.ProductModels;
using OnlineShop.Api.Services;

namespace OnlineShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageService service;
        private readonly AppDbContext dbContext;
        private readonly IWebHostEnvironment _env;

        public ImageController(
            IImageService servicem,
            AppDbContext dbContext,
            IWebHostEnvironment env)
        {
            this.service = service;
            this.dbContext = dbContext;
            this._env = env;
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

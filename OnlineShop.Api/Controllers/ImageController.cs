using Microsoft.AspNetCore.Mvc;
using OnlineShop.Api.Data;
using OnlineShop.Api.Models.ProductModels;
using OnlineShop.Api.Services;
using static OnlineShop.Api.Dtos.UserDtos.ServiceResponse;

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
        [HttpGet("Images")]
        public async Task<IActionResult> GetImagesAsync()
            => Ok(await service.GetImagesAsync());

        [HttpGet("Image/{id}")]
        public async Task<IActionResult> GetImagesAsync([FromRoute] Guid id)
            => Ok(await service.GetImageAsync(id));

        [HttpGet("ImageProductId/{productId}")]
        public async Task<IActionResult> GetImageProductIdAsync([FromRoute] Guid productId)
            => Ok(await service.GetImageProductIdAsync(productId));

        [HttpGet("ProductImage/{productId}")]
        public async Task<IActionResult> GetProductImageAsync([FromRoute] Guid productId)
            => Ok(await service.GetProductImageAsync(productId));

        [HttpPost("SetImage")]
        public async Task<GeneralResopnse> SaveImageAsync(Guid productId, IFormFile file)
        {
            string fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            string path = Path.Combine(_env.WebRootPath, $"Images/{fileName}");

            FileStream fileStream = System.IO.File.Open(path, FileMode.Create);
            await file.OpenReadStream().CopyToAsync(fileStream);

            fileStream.Flush();
            fileStream.Close();

            var image = new Image
            {
                Id = Guid.NewGuid(),
                FileName = fileName,
                FilePath = path,
                ProductId = productId,
                Created = DateTime.UtcNow.AddHours(5)
            };

            await dbContext.Images.AddAsync(image);
            await dbContext.SaveChangesAsync();

            return new GeneralResopnse(true, "Image successfully saved");
        }
    }
}

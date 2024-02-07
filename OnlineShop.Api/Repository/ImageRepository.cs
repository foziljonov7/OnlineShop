using Microsoft.EntityFrameworkCore;
using OnlineShop.Api.Data;
using OnlineShop.Api.Dtos.ImageDtos;
using OnlineShop.Api.Models.ProductModels;
using System.Data.Common;

namespace OnlineShop.Api.Repository
{
    public class ImageRepository : IImageRepository
    {
        private readonly AppDbContext dbContext;

        public ImageRepository(AppDbContext dbContext)
            => this.dbContext = dbContext;
        public async Task<bool> DeleteImageAsync(Guid id)
        {
            var image = await GetImageAsync(id);

            dbContext.Images.Remove(image);
            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Image> GetImageAsync(Guid id)
        {
            var image = await dbContext.Images
                .FirstOrDefaultAsync(i => i.Id == id);

            if (image == null)
                return null;

            return image;
        }

        public async Task<List<Image>> GetImageProductIdAsync(Guid productId)
        {
            var productImages = await dbContext.Images
                .Where(i => i.ProductId == productId)
                .Include(i => i.Product)
                .ToListAsync();

            if (productImages == null)
                return null;
                
            return productImages;
        }

        public async Task<List<Image>> GetProductImageAsync(Guid productId)
        {
            var product = await dbContext.Products
                .Where(p => p.Id == productId)
                .Include(p => p.Images)
                .FirstOrDefaultAsync();

            if (product is null || product.Images is null)
                return null;

            return product.Images.ToList();
        }

        public async Task<Image> SaveImageAsync(CreateImageDto newImage)
        {
            var uniqueName = $"{Guid.NewGuid()}-{newImage.FileName}";

            var imagePath = Path.Combine("wwwroot", "images", uniqueName);

            using(var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await newImage.ImageFile.CopyToAsync(fileStream);
            }

            var image = new Image
            {
                Id = Guid.NewGuid(),
                FileName = uniqueName,
                FilePath = imagePath,
                ProductId = newImage.ProductId,
                Created = DateTime.UtcNow
            };

            await dbContext.Images.AddAsync(image);
            await dbContext.SaveChangesAsync();

            return image;
        }
    }
}

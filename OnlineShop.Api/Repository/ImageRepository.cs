    using Microsoft.EntityFrameworkCore;
using OnlineShop.Api.Data;
using OnlineShop.Api.Dtos.ImageDtos;
using OnlineShop.Api.Models.ProductModels;
using System.Data.Common;
using System.IO.Pipelines;
using static OnlineShop.Api.Dtos.UserDtos.ServiceResponse;

namespace OnlineShop.Api.Repository
{
    public class ImageRepository : IImageRepository
    {
        private readonly AppDbContext dbContext;
        private readonly IWebHostEnvironment env;

        public ImageRepository(
            AppDbContext dbContext,
            IWebHostEnvironment env)
        {
            this.dbContext = dbContext;
            this.env = env;

        }
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

        public async Task<List<Image>> GetImagesAsync()
            => await dbContext.Images
                .Include(i => i.Product)
                .ToListAsync();

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
    }
}

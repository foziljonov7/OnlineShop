using OnlineShop.Api.Data;
using OnlineShop.Api.Dtos.ImageDtos;
using OnlineShop.Api.Models.ProductModels;

namespace OnlineShop.Api.Repository
{
    public class ImageRepository : IImageRepository
    {
        private readonly AppDbContext dbContext;

        public ImageRepository(AppDbContext dbContext)
            => this.dbContext = dbContext;
        public Task<Image> DeleteImageAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Image> GetImageAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Image>> GetImageProductIdAsync(Guid productId)
        {
            throw new NotImplementedException();
        }

        public Task<Image> SaveImageAsync(CreateImageDto newImage)
        {
            throw new NotImplementedException();
        }
    }
}

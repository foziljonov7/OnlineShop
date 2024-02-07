using OnlineShop.Api.Dtos.ImageDtos;
using OnlineShop.Api.Models.ProductModels;

namespace OnlineShop.Api.Repository
{
    public interface IImageRepository
    {
        Task<Image> GetImageAsync(Guid id);
        Task<List<Image>> GetProductImageAsync(Guid productId);
        Task<Image> SaveImageAsync(CreateImageDto newImage);
        Task<List<Image>> GetImageProductIdAsync(Guid productId);
        Task<bool> DeleteImageAsync(Guid id);
    }
}

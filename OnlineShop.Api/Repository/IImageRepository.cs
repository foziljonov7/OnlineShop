using OnlineShop.Api.Dtos.ImageDtos;
using OnlineShop.Api.Models.ProductModels;
using static OnlineShop.Api.Dtos.UserDtos.ServiceResponse;

namespace OnlineShop.Api.Repository
{
    public interface IImageRepository
    {
        Task<List<Image>> GetImagesAsync();
        Task<Image> GetImageAsync(Guid id);
        Task<List<Image>> GetProductImageAsync(Guid productId);
        Task<List<Image>> GetImageProductIdAsync(Guid productId);
        Task<bool> DeleteImageAsync(Guid id);
    }
}

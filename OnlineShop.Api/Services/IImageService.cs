using OnlineShop.Api.Models.ProductModels;
using OnlineShop.Api.ViewModels;

namespace OnlineShop.Api.Services
{
    public interface IImageService
    {
        Task<List<ImageViewModel>> GetImagesAsync();
        Task<ImageViewModel> GetImageAsync(Guid id);
        Task<List<ImageViewModel>> GetProductImageAsync(Guid productId);
        Task<List<ImageViewModel>> GetImageProductIdAsync(Guid productId);
        Task<bool> DeleteImageAsync(Guid id);
    }
}

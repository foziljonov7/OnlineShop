using OnlineShop.Api.Dtos.ImageDtos;
using OnlineShop.Api.ViewModels;

namespace OnlineShop.Api.Services
{
    public interface IImageService
    {
        Task<ImageViewModel> GetImageAsync(Guid id);
        Task<List<ImageViewModel>> GetProductImageAsync(Guid productId);
        Task<ImageViewModel> SaveImageAsync(CreateImageDto newImage);
        Task<List<ImageViewModel>> GetImageProductIdAsync(Guid productId);
        Task<bool> DeleteImageAsync(Guid id);
    }
}

using AutoMapper;
using OnlineShop.Api.Dtos.ImageDtos;
using OnlineShop.Api.Models.ProductModels;
using OnlineShop.Api.Repository;
using OnlineShop.Api.ViewModels;

namespace OnlineShop.Api.Services
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository service;
        private readonly IMapper mapper;

        public ImageService(
            IImageRepository service,
            IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }
       
        public async Task<bool> DeleteImageAsync(Guid id)
            => await service.DeleteImageAsync(id);

        public async Task<ImageViewModel> GetImageAsync(Guid id)
        {
            var image = await service.GetImageAsync(id);
            return (ImageViewModel)image;
        }

        public async Task<List<ImageViewModel>> GetImageProductIdAsync(Guid productId)
        {
            var images = await service.GetImageProductIdAsync(productId);
            return mapper.Map<List<Image>, List<ImageViewModel>>(images);
        }
        
        public async Task<List<ImageViewModel>> GetProductImageAsync(Guid productId)
        {
            var images = await service.GetProductImageAsync(productId);
            return mapper.Map<List<Image>, List<ImageViewModel>>(images);
        }

        public async Task<ImageViewModel> SaveImageAsync(CreateImageDto newImage)
        {
            var image = await service.SaveImageAsync(newImage);
            return (ImageViewModel)image;
        }
    }
}

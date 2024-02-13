using AutoMapper;
using OnlineShop.Api.Dtos.ImageDtos;
using OnlineShop.Api.Models.ProductModels;
using OnlineShop.Api.Repository;
using OnlineShop.Api.ViewModels;

namespace OnlineShop.Api.Services
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository repository;
        private readonly IMapper mapper;

        public ImageService(
            IImageRepository service,
            IMapper mapper)
        {
            this.repository = service;
            this.mapper = mapper;
        }
       
        public async Task<bool> DeleteImageAsync(Guid id)
            => await repository.DeleteImageAsync(id);

        public async Task<ImageViewModel> GetImageAsync(Guid id)
        {
            var image = await repository.GetImageAsync(id);
            return (ImageViewModel)image;
        }

        public async Task<List<ImageViewModel>> GetImageProductIdAsync(Guid productId)
        {
            var images = await repository.GetImageProductIdAsync(productId);
            return mapper.Map<List<Image>, List<ImageViewModel>>(images);
        }
        
        public async Task<List<ImageViewModel>> GetProductImageAsync(Guid productId)
        {
            var images = await repository.GetProductImageAsync(productId);
            return mapper.Map<List<Image>, List<ImageViewModel>>(images);
        }

        public async Task<ImageViewModel> SaveImageAsync(CreateImageDto newImage)
        {
            var image = await repository.SaveImageAsync(newImage);
            return (ImageViewModel)image;
        }
    }
}

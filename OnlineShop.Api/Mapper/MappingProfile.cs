using AutoMapper;
using OnlineShop.Api.Dtos.ImageDtos;
using OnlineShop.Api.Dtos.ProductDtos;
using OnlineShop.Api.Models.ProductModels;
using OnlineShop.Api.Models.Sold;
using OnlineShop.Api.Services;
using OnlineShop.Api.ViewModels;

namespace OnlineShop.Api.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductViewModel>();
            CreateMap<Image, ImageViewModel>();
            CreateMap<Category, CategoryViewModel>();
            CreateMap<SoldProduct, SoldProductViewModel>();
        }
    }
}

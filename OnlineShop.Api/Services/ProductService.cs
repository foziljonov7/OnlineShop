using AutoMapper;
using OnlineShop.Api.Dtos.ProductDtos;
using OnlineShop.Api.Models.ProductModels;
using OnlineShop.Api.Repository;
using OnlineShop.Api.ViewModels;
using System.Reflection.Metadata.Ecma335;

namespace OnlineShop.Api.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository repository;
        private readonly IMapper mapper;

        public ProductService(
            IProductRepository repository,
            IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public Task<ProductViewModel> CreateProductAsync(CreateProductDto newProduct)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteProductAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductViewModel> GetProductAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ProductViewModel>> GetProductsAsync()
        {
            var products = await repository.GetProductsAsync();

            var productViewModels = mapper.Map<List<Product>, List<ProductViewModel>>(products);
            return productViewModels;
        }

        public Task<List<ProductViewModel>> GetProductsByCategoryAsync(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductViewModel>> GetProductsByPriceRangeAsync(double minPrice, double maxPrice)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductViewModel>> GetProductsWithImagesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<(double totalPrice, int quantity)> SalesProductAsync(Guid id, int quantity)
        {
            throw new NotImplementedException();
        }

        public Task<ProductViewModel> UpdateProductAsync(Guid id, UpdateProductDto product)
        {
            throw new NotImplementedException();
        }
    }
}

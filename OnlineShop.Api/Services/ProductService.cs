using AutoMapper;
using OnlineShop.Api.Dtos.ProductDtos;
using OnlineShop.Api.Models.ProductModels;
using OnlineShop.Api.Repository;
using OnlineShop.Api.ViewModels;

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
        public async Task<ProductViewModel> CreateProductAsync(CreateProductDto newProduct)
        {
            var product = await repository.CreateProductAsync(newProduct);
            return (ProductViewModel)product;
        }

        public async Task<bool> DeleteProductAsync(Guid id)
        {
            var product = await repository.DeleteProductAsync(id);
            return product;
        }

        public async Task<ProductViewModel> GetProductAsync(Guid id)
        {
            var product = await repository.GetProductAsync(id);
            return (ProductViewModel)product;
        }

        public async Task<List<ProductViewModel>> GetProductsAsync()
        {
            var products = await repository.GetProductsAsync();
            return mapper.Map<List<Product>, List<ProductViewModel>>(products);
        }

        public async Task<List<ProductViewModel>> GetProductsByCategoryAsync(int categoryId)
        {
            var products = await repository.GetProductsByCategoryAsync(categoryId);
            return mapper.Map<List<Product>, List<ProductViewModel>>(products);
        }

        public async Task<List<ProductViewModel>> GetProductsByPriceRangeAsync(double minPrice, double maxPrice)
        {
            var products = await repository.GetProductsByPriceRangeAsync(minPrice, maxPrice); 
            return mapper.Map<List<Product>, List<ProductViewModel>>(products);
        }

        public async Task<List<ProductViewModel>> GetProductsWithImagesAsync()
        {
            var products = await repository.GetProductsWithImagesAsync();
            return mapper.Map<List<Product>, List<ProductViewModel>>(products);
        }

        public async Task<(double totalPrice, int quantity)> SalesProductAsync(Guid id, int quantity)
        {
            var product = await repository.SalesProductAsync(id, quantity);
            return product;
        }

        public async Task<ProductViewModel> UpdateProductAsync(Guid id, UpdateProductDto product)
        {
            var updateProduct = await repository.UpdateProductAsync(id, product);
            return (ProductViewModel)updateProduct;
        }
    }
}

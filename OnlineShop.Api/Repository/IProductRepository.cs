using OnlineShop.Api.Dtos.ProductDtos;
using OnlineShop.Api.Models.ProductModels;

namespace OnlineShop.Api.Repository
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProductsAsync();
        Task<Product> GetProductAsync(Guid id);
        Task<List<Product>> GetProductsWithImagesAsync();
        Task<Product> CreateProductAsync(CreateProductDto newProduct);
        Task<Product> UpdateProductAsync(Guid id, UpdateProductDto product); 
        Task<bool> DeleteProductAsync(Guid id); 
        Task<List<Product>> GetProductsByCategoryAsync(int categoryId); 
        Task<(double totalPrice, int quantity)> SalesProductAsync(Guid id, int quantity);
        Task<List<Product>> GetProductsByPriceRangeAsync(double minPrice, double maxPrice);

    }
}

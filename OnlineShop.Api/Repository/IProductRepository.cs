using OnlineShop.Api.Dtos.ProductDtos;
using OnlineShop.Api.Models.ProductModels;
using static OnlineShop.Api.Dtos.UserDtos.ServiceResponse;

namespace OnlineShop.Api.Repository
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProductsAsync();
        Task<Product> GetProductAsync(Guid id);
        Task<List<Product>> GetProductsWithImagesAsync();
        Task<GeneralResopnse> CreateProductAsync(CreateProductDto newProduct);
        Task<GeneralResopnse> UpdateProductAsync(Guid id, UpdateProductDto product); 
        Task<bool> DeleteProductAsync(Guid id); 
        Task<List<Product>> GetProductsByCategoryAsync(int categoryId); 
        Task<(double totalPrice, int quantity)> SalesProductAsync(Guid id, int quantity);
        Task<List<Product>> GetProductsByPriceRangeAsync(double minPrice, double maxPrice);

    }
}

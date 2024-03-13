using OnlineShop.App.Dtos;
using OnlineShop.Domain.Models.ProductModels;
using static OnlineShop.App.Helpers.ServiceResponse;

namespace OnlineShop.App.Services
{
    public interface IProductHttpClient
    {
        ValueTask<IEnumerable<Product>> GetProductsAsync();
        Task<Product> GetProductAsync(Guid id);
        Task<GeneralResponse> CreateProductAsync(ProductDto newProduct);
        Task<GeneralResponse> UpdateProductAsync(Guid id, ProductDto product);
        Task<GeneralResponse> DeleteProductAsync(Guid id);
    }
}

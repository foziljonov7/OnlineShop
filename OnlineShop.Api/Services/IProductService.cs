using OnlineShop.Api.Dtos.ProductDtos;
using OnlineShop.Api.Models.ProductModels;
using OnlineShop.Api.ViewModels;
using static OnlineShop.Api.Dtos.UserDtos.ServiceResponse;

namespace OnlineShop.Api.Services
{
    public interface IProductService
    {
        Task<List<ProductViewModel>> GetProductsAsync();
        Task<ProductViewModel> GetProductAsync(Guid id);
        Task<List<ProductViewModel>> GetProductsWithImagesAsync();
        Task<GeneralResopnse> CreateProductAsync(CreateProductDto newProduct);
        Task<GeneralResopnse> UpdateProductAsync(Guid id, UpdateProductDto product);
        Task<bool> DeleteProductAsync(Guid id);
        Task<List<ProductViewModel>> GetProductsByCategoryAsync(int categoryId);
        Task<(double totalPrice, int quantity)> SalesProductAsync(Guid id, int quantity);
        Task<List<ProductViewModel>> GetProductsByPriceRangeAsync(double minPrice, double maxPrice);
    }
}

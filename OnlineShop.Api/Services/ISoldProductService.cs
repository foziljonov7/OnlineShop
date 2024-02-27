using OnlineShop.Api.Models.Sold;

namespace OnlineShop.Api.Services
{
    public interface ISoldProductService
    {
        Task<List<SoldProduct>> GetSoldProducts();
        Task<SoldProduct> GetSoldProduct(Guid id);
        Task<(Guid id, Guid productId, double totalPrice)> GetReturnSoldProduct(Guid id);
    }
}

using OnlineShop.Api.Models.Sold;

namespace OnlineShop.Api.Repository
{
    public interface ISoldProductRepository
    {
        Task<List<SoldProduct>> GetSoldProducts();
        Task<SoldProduct> GetSoldProduct(Guid id);
        Task<(Guid productId, int quantity)> GetReturnSoldProduct(Guid id, int quantity);
    }
}

using OnlineShop.Api.Models.Sold;
using OnlineShop.Api.ViewModels;

namespace OnlineShop.Api.Services
{
    public interface ISoldProductService
    {
        Task<List<SoldProductViewModel>> GetSoldProducts();
        Task<SoldProductViewModel> GetSoldProduct(Guid id);
        Task<(Guid productId, int quantity)> GetReturnSoldProduct(Guid id, int quantity);
    }
}

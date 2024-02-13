using OnlineShop.Api.Models.ProductModels;
using OnlineShop.Api.ViewModels;

namespace OnlineShop.Api.Services
{
    public interface ICategoryService
    {
        Task<List<CategoryViewModel>> GetCategoriesAsync();
        Task<CategoryViewModel> GetCategoryAsync(int id);
        Task<CategoryViewModel> CreateCategoryAsync(string name);
        Task<bool> DeleteCategoryAsync(int id);
    }
}

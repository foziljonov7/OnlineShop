using OnlineShop.Api.Models.ProductModels;

namespace OnlineShop.Api.Repository
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetCategoriesAsync();
        Task<Category> GetCategoryAsync(int id);
        Task<Category> CreateCategoryAsync(string name);
        Task<bool> DeleteCategoryAsync(int id);
    }
}

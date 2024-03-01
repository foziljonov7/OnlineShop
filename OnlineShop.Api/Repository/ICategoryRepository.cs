using OnlineShop.Api.Models.ProductModels;
using static OnlineShop.Api.Dtos.UserDtos.ServiceResponse;

namespace OnlineShop.Api.Repository
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetCategoriesAsync();
        Task<Category> GetCategoryAsync(int id);
        Task<GeneralResopnse> CreateCategoryAsync(string name);
        Task<bool> DeleteCategoryAsync(int id);
    }
}

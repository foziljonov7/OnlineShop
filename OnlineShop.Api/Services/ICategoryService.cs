using OnlineShop.Api.Models.ProductModels;
using OnlineShop.Api.ViewModels;
using static OnlineShop.Api.Dtos.UserDtos.ServiceResponse;

namespace OnlineShop.Api.Services
{
    public interface ICategoryService
    {
        Task<List<CategoryViewModel>> GetCategoriesAsync();
        Task<CategoryViewModel> GetCategoryAsync(int id);
        Task<GeneralResopnse> CreateCategoryAsync(string name);
        Task<bool> DeleteCategoryAsync(int id);
    }
}

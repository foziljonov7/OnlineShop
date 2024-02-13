using AutoMapper;
using OnlineShop.Api.Models.ProductModels;
using OnlineShop.Api.Repository;
using OnlineShop.Api.ViewModels;

namespace OnlineShop.Api.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository service;
        private readonly IMapper mapper;

        public CategoryService(
            ICategoryRepository service,
            IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }
        public async Task<CategoryViewModel> CreateCategoryAsync(string name)
        {
            var category = await service.CreateCategoryAsync(name);
            return (CategoryViewModel)category;
        }

        public async Task<bool> DeleteCategoryAsync(int id)
            => await service.DeleteCategoryAsync(id);

        public async Task<List<CategoryViewModel>> GetCategoriesAsync()
        {
            var categories = await service.GetCategoriesAsync();
            return mapper.Map<List<Category>, List<CategoryViewModel>>(categories);
        }

        public async Task<CategoryViewModel> GetCategoryAsync(int id)
        {
            var category = await service.GetCategoryAsync(id);
            return (CategoryViewModel)category;
        }
    }
}

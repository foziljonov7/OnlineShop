using OnlineShop.Api.Data;
using OnlineShop.Api.Models.ProductModels;

namespace OnlineShop.Api.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext dbContext;

        public CategoryRepository(AppDbContext dbContext)
            => this.dbContext = dbContext;
        public Task<Category> CreateCategoryAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCategoryAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Category>> GetCategoriesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetCategoryAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}

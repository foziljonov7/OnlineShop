using Microsoft.EntityFrameworkCore;
using OnlineShop.Api.Data;
using OnlineShop.Api.Models.ProductModels;
using static OnlineShop.Api.Dtos.UserDtos.ServiceResponse;

namespace OnlineShop.Api.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext dbContext;

        public CategoryRepository(AppDbContext dbContext)
            => this.dbContext = dbContext;
        public async Task<GeneralResopnse> CreateCategoryAsync(string name)
        {
            if (name is null)
                return new GeneralResopnse(false, "Name is null");

            var category = new Category
            {
                Name = name
            };

            await dbContext.Categories.AddAsync(category);
            await dbContext.SaveChangesAsync();
            return new GeneralResopnse(true, "Successfully created");
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var category = await GetCategoryAsync(id);

            dbContext.Categories.Remove(category);
            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<Category>> GetCategoriesAsync()
            => await dbContext.Categories.ToListAsync();

        public async Task<Category> GetCategoryAsync(int id)
        {
            var category = await dbContext.Categories
                .FirstOrDefaultAsync(c => c.Id == id);

            if (category is null)
                return null;

            return category;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using OnlineShop.Api.Data;
using OnlineShop.Api.Dtos.ProductDtos;
using OnlineShop.Api.Models.ProductModels;

namespace OnlineShop.Api.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext dbContext;

        public ProductRepository(AppDbContext dbContext)
            => this.dbContext = dbContext;
        public Task<Product> CreateProductAsync(CreateProductDto newProduct)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteProductAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetProductAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> GetProductsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> GetProductsByCategoryAsync(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> GetProductsByPriceRangeAsync(double minPrice, double maxPrice)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Product>> GetProductsWithImagesAsync()
        {
            var productWithImages = await dbContext.Products
                .Include(p => p.Images)
                .ToListAsync();

            if (productWithImages is null)
                return null;

            return productWithImages;
        }

        public Task<(double totalPrice, int quantity)> SalesProductAsync(Guid id, int quantity)
        {
            throw new NotImplementedException();
        }

        public Task<Product> UpdateProductAsync(Guid id, UpdateProductDto product)
        {
            throw new NotImplementedException();
        }
    }
}

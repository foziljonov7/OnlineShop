using Microsoft.EntityFrameworkCore;
using OnlineShop.Api.Data;
using OnlineShop.Api.Dtos.ImageDtos;
using OnlineShop.Api.Dtos.ProductDtos;
using OnlineShop.Api.Models.ProductModels;
using OnlineShop.Api.Models.Sold;
using System.Xml;

namespace OnlineShop.Api.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext dbContext;

        public ProductRepository(AppDbContext dbContext)
            => this.dbContext = dbContext;
        public async Task<Product> CreateProductAsync(CreateProductDto newProduct)
        {
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Title = newProduct.Title,
                Price = newProduct.Price,
                Created = DateTime.UtcNow.AddHours(5),
                Description = newProduct.Description,
                Quantity = newProduct.Quantity,
                CategoryId = newProduct.CategoryId
            };

            await dbContext.Products.AddAsync(product);
            await dbContext.SaveChangesAsync();
            return product;
        }

        public async Task<bool> DeleteProductAsync(Guid id)
        {
            var product = await GetProductAsync(id);

            dbContext.Products.Remove(product);
            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Product> GetProductAsync(Guid id)
        {
            var product = await dbContext.Products
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product is null)
                return null;

            return product;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await dbContext.Products
                .Include(c => c.CategoryId)
                .Include(i => i.Images)
                .ToListAsync();
        }

        public async Task<List<Product>> GetProductsByCategoryAsync(int categoryId)
        {
            return await dbContext.Products
                .Where(p => p.CategoryId == categoryId)
                .ToListAsync();
        }

        public async Task<List<Product>> GetProductsByPriceRangeAsync(double minPrice, double maxPrice)
        {
            return await dbContext.Products
                .Where(p => p.Price >= minPrice && p.Price <= maxPrice)
                .ToListAsync();
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

        public async Task<(double totalPrice, int quantity)> SalesProductAsync(Guid id, int quantity)
        {
            var product = await dbContext.Products
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product is null)
                throw new ArgumentException("Product not found", nameof(id));

            if (product.Quantity <= 0)
                throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity must be greater than zero");

            if (product.Quantity < quantity)
                throw new InvalidOperationException("Insufficient quantity in stock");

            product.Quantity -= quantity;

            double totalPrice = product.Price * quantity;


            var Sold = new SoldProduct
            {
                Id = Guid.NewGuid(),
                Price = product.Price,
                TotalPrice = totalPrice,
                Quantity = quantity,
                ProductId = product.Id,
                SoldDate = DateTime.UtcNow.AddHours(5)
            };

            await dbContext.Solds.AddAsync(Sold);

            await dbContext.SaveChangesAsync();

            return (totalPrice, quantity);
        }

        public async Task<Product> UpdateProductAsync(Guid id, UpdateProductDto product)
        {
            var updateProduct = await GetProductAsync(id);

            if (product is null)
                return null;

            updateProduct.Title = product.Title;
            updateProduct.Price = product.Price;
            updateProduct.Description = product.Description;
            updateProduct.Updated = DateTime.UtcNow.AddHours(5);
            updateProduct.Quantity = product.Quantity;
            updateProduct.CategoryId = product.CategoryId;

            await dbContext.SaveChangesAsync();
            return updateProduct;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using OnlineShop.Api.Data;
using OnlineShop.Api.Models.Sold;

namespace OnlineShop.Api.Repository
{
    public class SoldProductRepository : ISoldProductRepository
    {
        private readonly AppDbContext dbContext;
        private readonly IProductRepository repository;

        public SoldProductRepository(
            AppDbContext dbContext,
            IProductRepository repository)
        {
            this.dbContext = dbContext;
            this.repository = repository;
        }
        public async Task<(Guid productId, int quantity)> GetReturnSoldProduct(Guid id, int quantity)
        {
            var soldProduct = await dbContext.Solds
                .FirstOrDefaultAsync(s => s.Id == id);

            var product = await repository.GetProductAsync(soldProduct.ProductId);

            if (soldProduct is null)
                throw new ArgumentException("Not found", nameof(id));

            soldProduct.Quantity -= quantity;

            product.Quantity += quantity;

            soldProduct.Price = 0;
            soldProduct.TotalPrice = 0;
            soldProduct.Quantity = 0;
            soldProduct.ProductId = product.Id;

            await dbContext.SaveChangesAsync();
            return (productId: product.Id, quantity: quantity);
        }

        public async Task<SoldProduct> GetSoldProduct(Guid id)
        {
            var sold = await dbContext.Solds
                .FirstOrDefaultAsync(s => s.Id == id);

            if (sold is null)
                return null;

            return sold;
        }

        public async Task<List<SoldProduct>> GetSoldProducts()
            => await dbContext.Solds.ToListAsync();
    }
}

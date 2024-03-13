using OnlineShop.App.Dtos;
using OnlineShop.Domain.Models.ProductModels;
using System.Text;
using System.Text.Json;
using static OnlineShop.App.Helpers.ServiceResponse;

namespace OnlineShop.App.Services
{
    public class ProductHttpClient : IProductHttpClient
    {
        private readonly HttpClient client;

        public ProductHttpClient(HttpClient client)
            => this.client = client;
        
        public async Task<GeneralResponse> CreateProductAsync(ProductDto newProduct)
        {
            if (newProduct is null || string.IsNullOrWhiteSpace(newProduct.Title))
                return new GeneralResponse(false, "Invalid product data");

            var json = JsonSerializer.Serialize(newProduct);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var httpResponse = await client.PostAsync("api/Product/Create", content);
            httpResponse.EnsureSuccessStatusCode();

            return new GeneralResponse(true, "Product created successfully");
        }

        public async Task<GeneralResponse> DeleteProductAsync(Guid id)
        {
            var productId = await GetProductAsync(id);

            if (productId is null)
                return new GeneralResponse(false, "Product not found");

            var httpResponse = await client.DeleteAsync($"api/Product/Delete{id}");

            httpResponse.EnsureSuccessStatusCode();

            return new GeneralResponse(true, "Product deleted successfully");
        }

        public async Task<Product> GetProductAsync(Guid id)
        {
            var httpResponse = await client.GetAsync($"api/Product/Product/{id}");

            httpResponse.EnsureSuccessStatusCode();

            var content = await httpResponse.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Product>(content);
        }

        public async ValueTask<IEnumerable<Product>> GetProductsAsync()
        {
            var httpResponse = await client.GetAsync("api/Product/Products");

            httpResponse.EnsureSuccessStatusCode();

            var content = await httpResponse.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<Product>>(content);
        }

        public async Task<GeneralResponse> UpdateProductAsync(Guid id, ProductDto product)
        {
            var productId = await GetProductAsync(id);

            if (productId is null || string.IsNullOrEmpty(product.Title))
                return new GeneralResponse(false, "Invalid product data");

            var json = JsonSerializer.Serialize(product);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var httpResponse = await client.PutAsync($"api/Product/Update/{id}", content);
            httpResponse.EnsureSuccessStatusCode();

            return new GeneralResponse(true, "Product updated successfully");
        }
    }
}

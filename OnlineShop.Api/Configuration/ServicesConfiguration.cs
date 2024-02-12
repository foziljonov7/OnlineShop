using OnlineShop.Api.Repository;
using OnlineShop.Api.Services;

namespace OnlineShop.Api.Configuration
{
    public static class ServicesConfiguration
    {
        public static void ConfigureRepository(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IImageRepository, ImageRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ISoldProductRepository, SoldProductRepository>();
        }

        // Services configuration
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ISoldProductService, SoldProductService>();
        }
    }
}

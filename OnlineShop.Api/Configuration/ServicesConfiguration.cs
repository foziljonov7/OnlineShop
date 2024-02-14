using FluentValidation;
using OnlineShop.Api.Dtos.ImageDtos;
using OnlineShop.Api.Dtos.ProductDtos;
using OnlineShop.Api.Repository;
using OnlineShop.Api.Services;
using OnlineShop.Api.Validator.ImaeValidator;
using OnlineShop.Api.Validator.ProductValidators;

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
        // Validator configuration
        public static void ConfigureValidator(this IServiceCollection services)
        {
            services.AddTransient<IValidator<CreateProductDto>, CreateProductValidator>();
            services.AddTransient<IValidator<UpdateProductDto>, UpdateProductValidator>();
            services.AddTransient<IValidator<CreateImageDto>, CreateImageValidator>();
        }
    }
}

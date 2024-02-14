using Microsoft.EntityFrameworkCore;
using OnlineShop.Api.Configuration;
using OnlineShop.Api.Data;

namespace OnlineShop.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        private readonly ILogger<Startup> logger;

        public void ConfigureServices(IServiceCollection services)
        {
            // Add DbContext
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("localhost")));

            // Configure repositories and services
            services.ConfigureRepository();
            services.ConfigureServices();
            services.ConfigureValidator();

            // Add AutoMapper
            services.AddAutoMapper(typeof(Startup));

            // Add controllers
            services.AddControllers();

            // Add Swagger
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                // Enable Swagger
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "OnlineShop.Api v1"));
            }

            // HTTPS redirection
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

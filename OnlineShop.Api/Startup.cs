using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using OnlineShop.Api.Configuration;
using OnlineShop.Api.Data;
using Swashbuckle.AspNetCore.Filters;
using System.Text;

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
            // Add AppDbContext
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("localhost")
                ?? throw new InvalidOperationException("Connection string is not found")));

            // Add UserIdentityDbContext
            services.AddDbContext<UserIdentityDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("localhost")
                ?? throw new InvalidOperationException("UserIdentity connection string is not found")));

            // Add Identity & JWT authentication
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<UserIdentityDbContext>()
                .AddSignInManager() 
                .AddRoles<IdentityRole>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidAudience = Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]!))
                };
            });

            // Configure repositories and services
            services.ConfigureRepository();
            services.ConfigureServices();
            services.ConfigureValidator();

            // Add AutoMapper
            services.AddAutoMapper(typeof(Startup));

            // Add controllers
            services.AddControllers();

            // Add Swagger
            services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });

                options.OperationFilter<SecurityRequirementsOperationFilter>();
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment() || env.IsProduction())
            {
                // Enable Swagger
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "OnlineShop.Api v1");
                    c.RoutePrefix = string.Empty;
                });
            }

            // HTTPS redirection
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }   
}

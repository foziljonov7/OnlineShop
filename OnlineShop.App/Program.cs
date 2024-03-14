using OnlineShop.App.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json");

builder.Services.AddControllersWithViews();

var app = builder.Build();
var baseUrl = builder.Configuration.GetSection("ShopApi")["BaseUrl"];

builder.Services.AddHttpClient<IProductHttpClient, ProductHttpClient>(client =>
    client.BaseAddress = new Uri(baseUrl));

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

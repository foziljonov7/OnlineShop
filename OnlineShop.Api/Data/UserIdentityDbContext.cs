using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace OnlineShop.Api.Data
{
    public class UserIdentityDbContext(DbContextOptions options) 
        : IdentityDbContext<ApplicationUser>(options)
    {
    }
}

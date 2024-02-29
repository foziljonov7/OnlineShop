using Microsoft.AspNetCore.Identity;

namespace OnlineShop.Api.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string? User { get; set; }
    }
}

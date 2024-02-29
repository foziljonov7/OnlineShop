using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Api.Dtos.UserDtos;
using OnlineShop.Api.Repository;

namespace OnlineShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController(IUserRepository userAccount) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserDTO userDTO)
            => Ok(await userAccount.CreateAccount(userDTO));

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
            => Ok(await userAccount.LoginAccount(loginDTO));
    }
}

using OnlineShop.Api.Dtos.UserDtos;
using static OnlineShop.Api.Dtos.UserDtos.ServiceResponse;

namespace OnlineShop.Api.Repository
{
    public interface IUserRepository
    {
        Task<GeneralResopnse> CreateAccount(UserDTO userDTO);
        Task<LoginResponse> LoginAccount(LoginDTO loginDTO);
    }
}

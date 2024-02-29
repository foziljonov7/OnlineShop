namespace OnlineShop.Api.Dtos.UserDtos
{
    public class ServiceResponse
    {
        public record class GeneralResopnse(bool Flag, string Message);
        public record class LoginResponse(bool Flag, string Token, string Message);
    }
}

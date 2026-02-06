namespace UMS.Api.Services.Auth
{
    public interface ITokenService
    {
        string CreateToken(int userId, string email, List<string> roles);
    }
}

namespace UMS.Api.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(int userId, string email, List<string> roles);
    }
}

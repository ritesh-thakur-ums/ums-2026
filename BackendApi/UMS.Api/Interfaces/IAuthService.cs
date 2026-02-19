using UMS.Api.DTOs.Auth;

namespace UMS.Api.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponseDto> LoginAsync(LoginRequestDto request);
    }
}

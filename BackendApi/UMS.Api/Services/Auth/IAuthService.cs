using UMS.Api.DTOs.Auth;

namespace UMS.Api.Services.Auth
{
    public interface IAuthService
    {
        Task<LoginResponseDto> LoginAsync(LoginRequestDto request);
    }
}

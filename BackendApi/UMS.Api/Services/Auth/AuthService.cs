using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using UMS.Api.Data;
using UMS.Api.Models;
using UMS.Api.DTOs.Auth;
using UMS.Api.Interfaces;

namespace UMS.Api.Services.Auth
{
    //Handles user authentication logic
    //Validates credentials and returns structured response
    public class AuthService : IAuthService
    {
    
        private readonly PasswordHasher<User> _passwordHasher;
        private readonly ILogger<AuthService> _logger;

        private readonly IUserRepository _userRepository;
        //private readonly ITokenService _tokenService;

        public AuthService(IUserRepository userRepository, ILogger<AuthService> logger)
        {
            _userRepository = userRepository;
            _passwordHasher = new PasswordHasher<User>();
            _logger = logger;
        }

        public async Task<LoginResponseDto> LoginAsync(LoginRequestDto request)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);

            if (user == null)
            {
                _logger.LogWarning("Login failed: user not found for {Email}", request.Email);
                return Fail("Invalid Credentials");
            }

            if (!user.IsActive)
            {
                _logger.LogWarning("Login failed: inactive user {Email}", request.Email);
                return Fail("User Inactive");
            }

            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, request.Password);

            if (result == PasswordVerificationResult.Failed)
            {
                _logger.LogWarning("Login failed: invalid password for {Email}", request.Email);
                return Fail("Invalid Credentials");
            }

            var roles = await _userRepository.GetUserRolesAsync(user.UserId);

            _logger.LogInformation("Login success for {Email}", request.Email);

            return new LoginResponseDto
            {
                Success = true,
                UserId = user.UserId,
                Email = user.Email,
                Roles = roles
            };
        }

        public LoginResponseDto Fail(string message)
        {
            return new LoginResponseDto
            {
                Success = false,
                Message = message
            };
        }
    }
}

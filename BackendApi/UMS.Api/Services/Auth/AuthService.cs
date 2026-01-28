using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using UMS.Api.Data;
using UMS.Api.Models;
using UMS.Api.DTOs.Auth;

namespace UMS.Api.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        private readonly PasswordHasher<User> _passwordHasher;

        public AuthService(AppDbContext context)
        {
            _context = context;
            _passwordHasher = new PasswordHasher<User>();

        }

        public async Task<LoginResponseDto> LoginAsync(LoginRequestDto request)
        {
            var user = await _context.Users
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .FirstOrDefaultAsync(u => u.Email == request.Email);

            if (user == null)
                return Fail("Invalid Credentials");

            if (!user.IsActive)
                return Fail("User Inactive");

            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, request.Password);

            if (result == PasswordVerificationResult.Failed)
                return Fail("Invalid Credentials");

            var roles = user.UserRoles.Select(r => r.Role.RoleName).ToList();

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

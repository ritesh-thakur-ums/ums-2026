using UMS.Api.Models;

namespace UMS.Api.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAsync(string email);
        Task<List<string>> GetUserRolesAsync(int userId);
        Task AddAsync(User user);
        Task SaveChangesAsync();
    }
}

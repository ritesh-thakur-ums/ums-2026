using UMS.Api.Models;

namespace UMS.Api.Interfaces
{
    public interface IProjectRepository
    {
        Task AddAsync(Project project);

        Task SaveChangesAsync();
    }
}

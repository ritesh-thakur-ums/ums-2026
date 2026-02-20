using UMS.Api.DTOs.Projects;

namespace UMS.Api.Interfaces
{
    public interface IProjectService
    {
        Task CreateProjectAsync(CreateProjectRequest request, int userId);
    }
}

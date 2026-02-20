using UMS.Api.DTOs;
using UMS.Api.DTOs.Projects;
using UMS.Api.Interfaces;
using UMS.Api.Models;

namespace UMS.Api.Services.Projects
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task CreateProjectAsync(CreateProjectRequest request, int userId)
        {
            var project = new Project
            {
                Name = request.Name,
                Description = request.Description,
                OwnerId = userId
            };

            await _projectRepository.AddAsync(project);

            await _projectRepository.SaveChangesAsync();
        }
    }
}

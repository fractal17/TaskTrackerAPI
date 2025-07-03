using TaskTracker.Application.DTOs;
using TaskTracker.Application.Interfaces;
using TaskTracker.Domain.Entities;

namespace TaskTracker.Infrastructure.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _repository;

        public ProjectService(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ProjectDto>> GetAllAsync(Guid userId)
        {
            var projects = await _repository.GetByUserIdAsync(userId);

            return projects.Select(p => new ProjectDto
            {
                Id = p.Id,
                Title = p.Title,
                Description = p.Description
            });
        }

        public async Task<ProjectDto?> GetByIdAsync(int id, Guid userId)
        {
            var project = await _repository.GetByIdAsync(id, userId);

            return project == null ? null : new ProjectDto
            {
                Id = project.Id,
                Title = project.Title,
                Description = project.Description
            };
        }

        public async Task<ProjectDto> CreateAsync(ProjectDto dto, Guid userId)
        {
            var project = new Project
            {
                Title = dto.Title,
                Description = dto.Description,
                UserId = userId
            };

            await _repository.AddAsync(project);

            dto.Id = project.Id;
            return dto;
        }

        public async Task<bool> UpdateAsync(int id, ProjectDto dto, Guid userId)
        {
            var project = await _repository.GetByIdAsync(id, userId);

            if (project == null)
                return false;

            project.Title = dto.Title;
            project.Description = dto.Description;

            await _repository.UpdateAsync(project);
            return true;
        }

        public async Task<bool> DeleteAsync(int id, Guid userId)
        {
            var project = await _repository.GetByIdAsync(id, userId);

            if (project == null)
                return false;

            await _repository.DeleteAsync(project);
            return true;
        }
    }
}

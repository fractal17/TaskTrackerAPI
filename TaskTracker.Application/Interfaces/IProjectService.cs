using TaskTracker.Application.DTOs;

namespace TaskTracker.Application.Interfaces
{
    public interface IProjectService
    {
        Task<IEnumerable<ProjectDto>> GetAllAsync(Guid userId);
        Task<ProjectDto?> GetByIdAsync(int id, Guid userId);
        Task<ProjectDto> CreateAsync(ProjectDto dto, Guid userId);
        Task<bool> UpdateAsync(int id, ProjectDto dto, Guid userId);
        Task<bool> DeleteAsync(int id, Guid userId);
    }
}

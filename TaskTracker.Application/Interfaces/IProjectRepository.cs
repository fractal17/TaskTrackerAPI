using TaskTracker.Domain.Entities;

namespace TaskTracker.Application.Interfaces
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> GetByUserIdAsync(Guid userId);
        Task<Project?> GetByIdAsync(int id, Guid userId);
        Task AddAsync(Project project);
        Task UpdateAsync(Project project);
        Task DeleteAsync(Project project);
    }
}

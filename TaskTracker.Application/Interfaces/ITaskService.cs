using TaskTracker.Application.DTOs;
using TaskTracker.Domain.Entities;

namespace TaskTracker.Application.Interfaces
{
    public interface ITaskService
    {
        Task<List<TaskItem>> GetAllAsync(Guid userId);
        Task<TaskItem?> GetByIdAsync(int id, Guid userId);
        Task<TaskItem> CreateAsync(TaskItemDto dto, Guid userId);
        Task<bool> UpdateAsync(int id, TaskItemDto dto, Guid userId);
        Task<bool> DeleteAsync(int id, Guid userId);
    }
}

using Microsoft.EntityFrameworkCore;
using TaskTracker.Application.DTOs;
using TaskTracker.Application.Interfaces;
using TaskTracker.Domain.Entities;
using TaskTracker.Infrastructure.Data;

namespace TaskTracker.Infrastructure.Services
{
    public class TaskService : ITaskService
    {
        private readonly AppDbContext _context;

        public TaskService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<TaskItem>> GetAllAsync(Guid userId)
        {
            return await _context.Tasks
                .Where(t => t.UserId == userId)
                .ToListAsync();
        }

        public async Task<TaskItem?> GetByIdAsync(int id, Guid userId)
        {
            return await _context.Tasks
                .FirstOrDefaultAsync(t => t.Id == id && t.UserId == userId);
        }

        public async Task<TaskItem> CreateAsync(TaskItemDto dto, Guid userId)
        {
            var task = new TaskItem
            {
                Title = dto.Title,
                Description = dto.Description,
                IsCompleted = dto.IsCompleted,
                ProjectId = dto.ProjectId,
                UserId = userId
            };

            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<bool> UpdateAsync(int id, TaskItemDto dto, Guid userId)
        {
            var task = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id && t.UserId == userId);
            if (task == null) return false;

            task.Title = dto.Title;
            task.Description = dto.Description;
            task.IsCompleted = dto.IsCompleted;
            task.ProjectId = dto.ProjectId;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id, Guid userId)
        {
            var task = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id && t.UserId == userId);
            if (task == null) return false;

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

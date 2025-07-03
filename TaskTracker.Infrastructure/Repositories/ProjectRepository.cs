using Microsoft.EntityFrameworkCore;
using System;
using TaskTracker.Application.Interfaces;
using TaskTracker.Domain.Entities;
using TaskTracker.Infrastructure.Data;

namespace TaskTracker.Infrastructure.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly AppDbContext _context;

        public ProjectRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Project>> GetByUserIdAsync(Guid userId)
        {
            return await _context.Projects
                .Where(p => p.UserId == userId)
                .ToListAsync();
        }

        public async Task<Project?> GetByIdAsync(int id, Guid userId)
        {
            return await _context.Projects
                .FirstOrDefaultAsync(p => p.Id == id && p.UserId == userId);
        }

        public async Task AddAsync(Project project)
        {
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Project project)
        {
            _context.Projects.Update(project);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Project project)
        {
            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
        }
    }
}

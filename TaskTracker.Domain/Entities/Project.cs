using System;
using System.Collections.Generic;

namespace TaskTracker.Domain.Entities
{
    public class Project
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        public Guid UserId { get; set; }

        public ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();
    }
}

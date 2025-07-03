﻿using System;

namespace TaskTracker.Domain.Entities
{
    public class TaskItem
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        public bool IsCompleted { get; set; }

        public Guid UserId { get; set; }

        public int ProjectId { get; set; }

        public Project Project { get; set; } = null!;  
    }
}

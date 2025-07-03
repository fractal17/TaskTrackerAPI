namespace TaskTracker.Application.DTOs
{
    public class TaskItemDto
    {
        public string Title { get; set; } = default!;
        public string? Description { get; set; }
        public bool IsCompleted { get; set; }
        public int ProjectId { get; set; }
    }
}

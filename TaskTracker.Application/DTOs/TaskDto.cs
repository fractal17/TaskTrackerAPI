namespace TaskTracker.Application.DTOs
{
    public class TaskDto
    {
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsCompleted { get; set; }
        public int ProjectId { get; set; }  
    }
}

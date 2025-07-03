namespace TaskTracker.Application.DTOs;

public class ProjectDto
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }
}

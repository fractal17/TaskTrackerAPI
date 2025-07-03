using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskTracker.Application.DTOs;
using TaskTracker.Application.Interfaces;

namespace TaskTracker.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ProjectsController : ControllerBase
{
    private readonly IProjectService _service;

    public ProjectsController(IProjectService service)
    {
        _service = service;
    }

    private Guid GetUserId()
    {
        return Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var userId = GetUserId();
        var projects = await _service.GetAllAsync(userId);
        return Ok(projects);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var userId = GetUserId();
        var project = await _service.GetByIdAsync(id, userId);
        if (project == null) return NotFound();
        return Ok(project);
    }

    [HttpPost]
    public async Task<IActionResult> Create(ProjectDto dto)
    {
        var userId = GetUserId();
        var created = await _service.CreateAsync(dto, userId);
        return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, ProjectDto dto)
    {
        var userId = GetUserId();
        var success = await _service.UpdateAsync(id, dto, userId);
        if (!success) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var userId = GetUserId();
        var success = await _service.DeleteAsync(id, userId);
        if (!success) return NotFound();
        return NoContent();
    }
}

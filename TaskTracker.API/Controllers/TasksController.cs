using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskTracker.Application.DTOs;
using TaskTracker.Application.Interfaces;

namespace TaskTracker.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _service;

        public TasksController(ITaskService service)
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
            var tasks = await _service.GetAllAsync(userId);
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var userId = GetUserId();
            var task = await _service.GetByIdAsync(id, userId);
            if (task == null) return NotFound();
            return Ok(task);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskItemDto dto)
        {
            var userId = GetUserId();
            var created = await _service.CreateAsync(dto, userId);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TaskItemDto dto)
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
}

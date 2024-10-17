using Assesment_CRUD.Models;
using Assesment_CRUD.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Assesment_CRUD.Controllers
{ 
        [Authorize]
        [Route("api/[controller]")]
        [ApiController]

        public class ToDoController : ControllerBase
        {
            private readonly ITaskService _taskService;

            public ToDoController(ITaskService taskService)
            {
                _taskService = taskService;
            }

            [HttpGet]
            public async Task<IActionResult> GetTasks()
            {
                var userId = User.Identity.Name;
                var tasks = await _taskService.GetTasksByUserAsync(userId);
                return Ok(tasks);
            }

            [HttpPost]
            public async Task<IActionResult> AddTask([FromBody] TaskDto taskDto)
            {
                var userId = User.Identity.Name;
                var task = await _taskService.AddTaskAsync(taskDto, userId);
                return CreatedAtAction(nameof(GetTasks), new { id = task.Id }, task);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> UpdateTask(int id, [FromBody] TaskDto taskDto)
            {
                var userId = User.Identity.Name;
                var success = await _taskService.UpdateTaskAsync(id, taskDto, userId);
                if (!success) return NotFound();
                return NoContent();
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteTask(int id)
            {
                var userId = User.Identity.Name;
                var success = await _taskService.DeleteTaskAsync(id, userId);
                if (!success) return NotFound();
                return NoContent();
            }
        }
    } 

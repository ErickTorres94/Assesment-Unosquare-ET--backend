using Assesment_CRUD.Models;
using Assesment_CRUD.Repository;
using Microsoft.EntityFrameworkCore;

namespace Assesment_CRUD.Services.Implementations
{
    public class TaskService: ITaskService
    {
        private readonly ToDoContext _context;

        public TaskService(ToDoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ToDoTask>> GetTasksByUserAsync(string userId)
        {
            return await _context.ToDoTasks.Where(t => t.UserId == userId).ToListAsync();
        }

        public async Task<ToDoTask> AddTaskAsync(TaskDto taskDto, string userId)
        {
            var task = new ToDoTask
            {
                Title = taskDto.Title,
                IsDone = taskDto.IsDone,
                UserId = userId
            };
            _context.ToDoTasks.Add(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<bool> UpdateTaskAsync(int id, TaskDto taskDto, string userId)
        {
            var task = await _context.ToDoTasks.FirstOrDefaultAsync(t => t.Id == id && t.UserId == userId);
            if (task == null) return false;

            task.Title = taskDto.Title;
            task.IsDone = taskDto.IsDone;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteTaskAsync(int id, string userId)
        {
            var task = await _context.ToDoTasks.FirstOrDefaultAsync(t => t.Id == id && t.UserId == userId);
            if (task == null) return false;

            _context.ToDoTasks.Remove(task);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

using Assesment_CRUD.Models;

namespace Assesment_CRUD.Services
{
    /// <summary>
    /// Service Interface
    /// </summary>
    public interface ITaskService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<IEnumerable<ToDoTask>> GetTasksByUserAsync(string userId);
        Task<ToDoTask> AddTaskAsync(TaskDto taskDto, string userId);
        Task<bool> UpdateTaskAsync(int id, TaskDto taskDto, string userId);
        Task<bool> DeleteTaskAsync(int id, string userId);
    }
}

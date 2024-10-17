

namespace Assesment.CRUD.Tests
{
   

    public class TaskServiceTests
	{
		private readonly ITaskService _taskService;

		public TaskServiceTests()
		{
			var options = new DbContextOptionsBuilder<ToDoContext>()
				.UseInMemoryDatabase(databaseName: "test")
				.Options;
			var context = new ToDoContext(options);
			_taskService = new TaskService(context);
		}

		[Fact]
		public async Task AddTaskAsync_ShouldAddTask()
		{
			var taskDto = new TaskDTO { Title = "Test Task", IsDone = false };
			var result = await _taskService.AddTaskAsync(taskDto, "erick.torres@unosquare.com");
			Assert.NotNull(result);
			Assert.Equal("Test Task", result.Title);
		}
		 
	}
}

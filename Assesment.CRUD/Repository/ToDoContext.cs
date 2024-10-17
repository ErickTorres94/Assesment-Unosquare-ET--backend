using Assesment_CRUD.Models;
using Microsoft.EntityFrameworkCore;
  
namespace Assesment_CRUD.Repository
{
    public class ToDoContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public Microsoft.EntityFrameworkCore.DbSet<ToDoTask> ToDoTasks { get; set; }

        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options) { }
    }
}

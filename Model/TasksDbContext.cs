using Microsoft.EntityFrameworkCore;

namespace WebApi2.Model
{
    public class TasksDbContext : DbContext
    {
        // Requerido para configuraciones
        public TasksDbContext(DbContextOptions<TasksDbContext> options)
    : base(options)
        {
        }


        public DbSet<Task> tasks { get; set; }
        public DbSet<User> users { get; set; }

    }

    public class User
    {
        public int UserId { get; set; }
        public String? Name { get; set; }

    }

    public class Task
    {
        public int TaskId { get; set; }
        public String? Title { get; set; }
        public DateTime CreatedAt { get; set; }

        public int UserId { get; set; }

        public bool IsActive { get; set; }

    }
}

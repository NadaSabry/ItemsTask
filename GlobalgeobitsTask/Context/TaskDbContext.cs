using GlobalgeobitsTask.Models;
using Microsoft.EntityFrameworkCore;

namespace GlobalgeobitsTask.Context
{
    public class TaskDbContext :DbContext
    {
        public TaskDbContext(DbContextOptions<TaskDbContext> options):base(options)
        {
                
        }
        public DbSet<Item> Items { get; set; }
    }
}

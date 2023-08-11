using Microsoft.EntityFrameworkCore;
using ToDoList.Data.Configuration;
using ToDoList.Models;

namespace ToDoList.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions dbContext )
            : base (dbContext)
        {
            
        }
        public DbSet<User> Users { get; set; } 
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<EventTask> EventTasks { get; set; }
        public DbSet<TravelTask> TravelTasks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.
                ApplyConfigurationsFromAssembly
                (typeof(UserConfiguration).Assembly); 
        }
    }
}

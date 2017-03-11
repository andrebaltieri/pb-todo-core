using Microsoft.EntityFrameworkCore;

namespace Todo.Infra.Contexts
{
    public class TodoDataContext : DbContext
    {
        public DbSet<Todo.Domain.Entities.Todo> Todos { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseInMemoryDatabase();
        }
    }
}
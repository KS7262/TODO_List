using Microsoft.EntityFrameworkCore;
using todoList.Entities;

namespace todoList
{
    public class TodoContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Todo> Todoes { get; set; }

        public TodoContext()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = TODODataBase; Trusted_Connection = True; MultipleActiveResultSets = true");
        }
    }
}

using Innovation_Task.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Innovation_Task.Entities
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options) { }


        public DbSet<Employee> Employees { get; set; }
    }
}

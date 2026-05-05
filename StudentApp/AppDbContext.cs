using Microsoft.EntityFrameworkCore;
using StudentApp.Models;

namespace StudentApp
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Students> Students { get; set; }
        public DbSet<Teachers> Teachers { get; set; }
        public DbSet<Lessons> Lessons { get; set; }
        public DbSet<Books> Books { get; set; }
    }
}

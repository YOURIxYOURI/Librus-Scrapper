using API.DBOs;
using Microsoft.EntityFrameworkCore;

namespace API
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<GradesDBO> Grades { get; set; }
        public DbSet<StudentDBO> Students { get; set; }
    }
}

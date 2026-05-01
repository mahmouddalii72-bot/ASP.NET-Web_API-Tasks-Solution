using Microsoft.EntityFrameworkCore;

namespace Day01_Task.Data.DbContexts
{
    public class CourseDbContext : DbContext
    {
        public CourseDbContext(DbContextOptions<CourseDbContext> options) : base(options)
        {
        }
        public DbSet<Entites.Course> Courses { get; set; }
    }
}

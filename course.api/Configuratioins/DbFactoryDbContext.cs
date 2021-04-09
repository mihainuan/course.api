using course.api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace course.api.Configuratioins
{
    public class DbFactoryDbContext : IDesignTimeDbContextFactory<CourseDbContext>
    {
        CourseDbContext IDesignTimeDbContextFactory<CourseDbContext>.CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CourseDbContext>();
            optionsBuilder.UseSqlServer("Server=localhost;Database=CourseDb;User=sa;Password=hakunamatata");
            CourseDbContext context = new CourseDbContext(optionsBuilder.Options);
            return context;
        }
    }
}

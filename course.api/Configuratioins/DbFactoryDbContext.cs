using course.api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace course.api.Configuratioins
{
    public class DbFactoryDbContext : IDesignTimeDbContextFactory<CourseDbContext>
    {
        private readonly IConfiguration _config;

        CourseDbContext IDesignTimeDbContextFactory<CourseDbContext>.CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CourseDbContext>();
                        
            //optionsBuilder.UseSqlServer("Server=localhost;Database=CourseDb;User=sa;Password=hakunamatata");

            optionsBuilder.UseSqlServer(_config.GetConnectionString("DefaultConnection"));
            CourseDbContext context = new CourseDbContext(optionsBuilder.Options);
            return context;
        }
    }
}

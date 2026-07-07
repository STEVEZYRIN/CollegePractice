using Microsoft.EntityFrameworkCore;

namespace CollegePractice;

public class AppDbContext : DbContext
{
    public DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = ConfigurationHelper.GetConnectionString();
        optionsBuilder.UseSqlServer(connectionString);
    }
}
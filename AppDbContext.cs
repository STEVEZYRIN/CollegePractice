using Microsoft.EntityFrameworkCore;

namespace CollegePractice;

/// <summary>
/// Контекст базы данных для Entity Framework Core.
/// </summary>
public class AppDbContext : DbContext
{
    /// <summary>
    /// Коллекция студентов в базе данных.
    /// </summary>
    public DbSet<Student> Students { get; set; }

    /// <summary>
    /// Настраивает подключение к базе данных, читая строку подключения из конфигурации.
    /// </summary>
    /// <param name="optionsBuilder">Билдер опций контекста.</param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = ConfigurationHelper.GetConnectionString();
        optionsBuilder.UseSqlite(connectionString);
    }
}

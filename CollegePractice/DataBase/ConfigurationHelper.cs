using Microsoft.Extensions.Configuration;

namespace CollegePractice;

/// <summary>
/// Вспомогательный класс для чтения настроек из конфигурационного файла.
/// </summary>
public static class ConfigurationHelper
{
    private static readonly IConfiguration _configuration;

    static ConfigurationHelper()
    {
        _configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();
    }

    /// <summary>
    /// Возвращает строку подключения к базе данных из конфигурации.
    /// </summary>
    /// <returns>Строка подключения.</returns>
    public static string GetConnectionString()
    {
        return _configuration.GetConnectionString("DefaultConnection") 
               ?? throw new InvalidOperationException("Строка подключения не найдена в конфигурации.");
    }
}

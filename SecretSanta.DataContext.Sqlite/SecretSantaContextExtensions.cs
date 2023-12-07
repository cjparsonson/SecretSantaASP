using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace SecretSanta.EntityModels;

public static class SecretSantaContextExtensions
{
    public static IServiceCollection AddSecretSantaContext(
        this IServiceCollection services,
        string relativePath = "..",
        string databaseName = "SecretSanta.db")
    {
        string path = Path.Combine(relativePath, databaseName);
        path = Path.GetFullPath(path);
        SecretSantaContextLogger.WriteLine($"Using database file: {path}");
        if (!File.Exists(path))
        {
            throw new FileNotFoundException(
                  message: $"{path} not found.", fileName: path);
        }
        services.AddDbContext<SecretSantaContext>(options =>
        {
            options.UseSqlite($"Data Source={path}");
            options.LogTo(SecretSantaContextLogger.WriteLine,
                               new[] { Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.CommandExecuting });
        },
        contextLifetime: ServiceLifetime.Transient,
        optionsLifetime: ServiceLifetime.Transient);
        return services;
    }
}
using Itmo.Dev.Platform.Postgres.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace CashMachine.Infrastructure.DataAccess.Extensions;

/// <summary>
/// Предоставляет расширения для использования доступа к данным в рамках IServiceScope.
/// </summary>
public static class ServiceScopeExtensions
{
    /// <summary>
    /// Метод для использования доступа к данным в рамках IServiceScope.
    /// </summary>
    /// <param name="scope">Область служб.</param>
    public static void UseInfrastructureDataAccess(this IServiceScope scope)
    {
        scope.UsePlatformMigrationsAsync(default).GetAwaiter().GetResult();
    }
}


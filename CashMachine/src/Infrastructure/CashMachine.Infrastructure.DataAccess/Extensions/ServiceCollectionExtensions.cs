using CashMachine.Application.Abstractions.Reposituries;
using CashMachine.Application.Abstractions.Reposituries.Managers;
using CashMachine.Infrastructure.DataAccess.Managers;
using CashMachine.Infrastructure.DataAccess.Repositories;
using Itmo.Dev.Platform.Postgres.Extensions;
using Itmo.Dev.Platform.Postgres.Models;
using Microsoft.Extensions.DependencyInjection;

namespace CashMachine.Infrastructure.DataAccess.Extensions;

/// <summary>
/// Предоставляет расширения для регистрации служб доступа к данным в коллекции сервисов.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Расширение для добавления служб доступа к данным в коллекцию сервисов.
    /// </summary>
    /// <param name="services">Коллекция сервисов.</param>
    /// <param name="configuration">Конфигурация подключения к базе данных Postgres.</param>
    public static IServiceCollection AddInfrastructureDataAccess(
        this IServiceCollection services,
        Action<PostgresConnectionConfiguration> configuration)
    {
        services.AddPlatformPostgres(builder => builder.Configure(configuration));
        services.AddPlatformMigrations(typeof(ServiceCollectionExtensions).Assembly);

        services.AddScoped<IBankAccountHistoryRepository, BankAccountHistoryRepository>();
        services.AddScoped<IBankAccountRepository, BankAccountRepository>();
        services.AddScoped<IRepositoryManager, RepositoryManager>();

        return services;
    }
}


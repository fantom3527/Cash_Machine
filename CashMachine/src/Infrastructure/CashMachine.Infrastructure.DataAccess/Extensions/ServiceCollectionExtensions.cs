using CashMachine.Application.Abstractions.Reposituries;
using CashMachine.Application.Abstractions.Reposituries.Managers;
using CashMachine.Infrastructure.DataAccess.Managers;
using CashMachine.Infrastructure.DataAccess.Repositories;
using Itmo.Dev.Platform.Postgres.Extensions;
using Itmo.Dev.Platform.Postgres.Models;
using Microsoft.Extensions.DependencyInjection;

namespace CashMachine.Infrastructure.DataAccess.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureDataAccess(
        this IServiceCollection services,
        Action<PostgresConnectionConfiguration> configuration)
    {
        services.AddPlatformPostgres(builder => builder.Configure(configuration));
        services.AddPlatformMigrations(typeof(ServiceCollectionExtensions).Assembly);

        //TODO: проверить надо ли добавлять маппинг collection.AddSingleton<IDataSourcePlugin, MappingPlugin>();

        services.AddScoped<IBankAccountHistoryRepository, BankAccountHistoryRepository>();
        services.AddScoped<IBankAccountRepository, BankAccountRepository>();
        services.AddScoped<IRepositoryManager, RepositoryManager>();

        return services;
    }
}


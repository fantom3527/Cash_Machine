using CashMachine.Presentation.Console.Scenarios.Login.Admin;
using CashMachine.Presentation.Console.Scenarios.Login.Customer;
using Microsoft.Extensions.DependencyInjection;

namespace CashMachine.Presentation.Console.Extensions;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentationConsole(this IServiceCollection collection)
    {
        collection.AddScoped<ScenarioRunner>();

        // TODO: проверить.
        collection.AddScoped<IScenarioProvider, LoginCustomerScenarioProvider>();
        collection.AddScoped<IScenarioProvider, LoginAdminScenarioProvider>();

        return collection;
    }
}


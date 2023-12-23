using CashMachine.Presentation.Console.Scenarios.BankAccount.AdminScenarios.GetAll;
using CashMachine.Presentation.Console.Scenarios.BankAccount.CustomerScenarios.Create;
using CashMachine.Presentation.Console.Scenarios.BankAccount.CustomerScenarios.GetAllHistory;
using CashMachine.Presentation.Console.Scenarios.BankAccount.CustomerScenarios.GetBalance;
using CashMachine.Presentation.Console.Scenarios.BankAccount.CustomerScenarios.TopUpMoney;
using CashMachine.Presentation.Console.Scenarios.BankAccount.CustomerScenarios.WithdrawMoney;
using CashMachine.Presentation.Console.Scenarios.Login.Admin;
using CashMachine.Presentation.Console.Scenarios.Login.Customer;
using Microsoft.Extensions.DependencyInjection;

namespace CashMachine.Presentation.Console.Extensions;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentationConsole(this IServiceCollection collection)
    {
        collection.AddScoped<ScenarioRunner>();

        collection.AddScoped<ILoginScenarioProvider, LoginCustomerScenarioProvider>();
        collection.AddScoped<ILoginScenarioProvider, LoginAdminScenarioProvider>();

        collection.AddScoped<ICustomerScenarioProvider, CreateBankAccountScenarioProvider>();
        collection.AddScoped<ICustomerScenarioProvider, GetBalanceBAScenarioProvider>();
        collection.AddScoped<ICustomerScenarioProvider, GetAllHistoryByBAScenarioProvider>();
        collection.AddScoped<ICustomerScenarioProvider, TopUpMoneyBAScenarioProvider>();
        collection.AddScoped<ICustomerScenarioProvider, WithdrawMoneyBAScenarioProvider>();
        collection.AddScoped<IAdminScenarioProvider, GetAllBAScenarioProvider>();

        return collection;
    }
}


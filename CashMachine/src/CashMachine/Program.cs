using Microsoft.Extensions.DependencyInjection;
using CashMachine.Application.Extensions;
using CashMachine.Infrastructure.DataAccess.Extensions;
using CashMachine.Presentation.Console.Extensions;
using CashMachine.Presentation.Console;
using Spectre.Console;

var services = new ServiceCollection();

services
    .AddApplication()
    .AddInfrastructureDataAccess(configuration =>
    {
        //TODO:поменять для Docker настройки
        configuration.Host = "postgres_db";
        configuration.Port = 5432; //6432;
        configuration.Username = "postgres";
        configuration.Password = "123";
        configuration.Database = "testcashmachine";
        configuration.SslMode = "Prefer";
    })
    .AddPresentationConsole();

var provider = services.BuildServiceProvider();
using var scope = provider.CreateScope();

scope.UseInfrastructureDataAccess();

var scenarioRunner = scope.ServiceProvider
    .GetRequiredService<ScenarioRunner>();

while (true)
{
    scenarioRunner.Run();
    AnsiConsole.Clear();
}
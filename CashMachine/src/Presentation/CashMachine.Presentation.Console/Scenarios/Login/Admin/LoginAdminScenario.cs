using CashMachine.Application.Contracts.Services.Users;
using Spectre.Console;

namespace CashMachine.Presentation.Console.Scenarios.Login.Admin;

public class LoginAdminScenario : IScenario
{
    private readonly IEnumerable<ICustomerScenarioProvider> _providers;
    private readonly IUserService _userService;
    public string Name => "Login as admin";

    public LoginAdminScenario(IEnumerable<ICustomerScenarioProvider> providers, IUserService userService)
    {
        _providers = providers;
        _userService = userService;
    }
    public void Run()
    {
        var password = AnsiConsole.Ask<string>("Enter your password");
        var result = _userService.LoginAsAdmin(password);

        var message = result switch
        {
            LoginResult.Success => "Successful login",
            LoginResult.NotFound => "User not found",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.Clear();
        AnsiConsole.MarkupLine($"[green]{message}[/]");

        IEnumerable<IScenario> scenarios = GetScenarios();

        SelectionPrompt<IScenario> selector = new SelectionPrompt<IScenario>()
            .Title("Select action")
            .AddChoices(scenarios)
            .UseConverter(x => x.Name);

        var scenario = AnsiConsole.Prompt(selector);
        scenario.Run();
    }

    private IEnumerable<IScenario> GetScenarios()
    {
        foreach (var provider in _providers)
        {
            if (provider.TryGetScenario(out var scenario))
                yield return scenario;
        }
    }
}


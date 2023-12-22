using CashMachine.Application.Contracts.Users;
using Spectre.Console;

namespace CashMachine.Presentation.Console.Scenarios.Login.Admin;

public class LoginAdminScenario : IScenario
{
    private readonly IUserService _userService;
    public string Name => "Login as admin";

    public LoginAdminScenario(IUserService userService)
    {
        _userService = userService;
    }
    public void Run()
    {
        var password = AnsiConsole.Ask<string>("Enter your username");

        var result = _userService.LoginAsAdmin(password);

        var message = result switch
        {
            LoginResult.Success => "Successful login",
            LoginResult.NotFound => "User not found",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");
    }
}


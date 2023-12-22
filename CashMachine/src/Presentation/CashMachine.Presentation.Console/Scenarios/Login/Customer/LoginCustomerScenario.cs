using CashMachine.Application.Contracts.Users;
using Spectre.Console;

namespace CashMachine.Presentation.Console.Scenarios.Login.Customer;

public class LoginCustomerScenario : IScenario
{
    private readonly IUserService _userService;
    public string Name => "Login as customer";

    public LoginCustomerScenario(IUserService userService)
    {
        _userService = userService;
    }

    public void Run()
    {
        var number = AnsiConsole.Ask<ushort>("Enter your number");
        var password = AnsiConsole.Ask<string>("Enter your password");

        var result = _userService.LoginAsCustomer(number, password);

        //var message = result switch
        //{
        //    LoginResult.Success => "Successful login",
        //    LoginResult.NotFound => "User not found",
        //    _ => throw new ArgumentOutOfRangeException(nameof(result)),
        //};

        //AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");
    }
}

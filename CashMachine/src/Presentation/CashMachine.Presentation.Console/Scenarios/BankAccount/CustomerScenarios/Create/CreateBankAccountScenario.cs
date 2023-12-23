using CashMachine.Application.Contracts.Managers;
using CashMachine.Application.Contracts.Services.BankAccounts;
using Spectre.Console;

namespace CashMachine.Presentation.Console.Scenarios.BankAccount.CustomerScenarios.Create
{
    public class CreateBankAccountScenario : IScenario
    {
        private readonly IBankAccountService _bankAccountService;
        private readonly ICurrentUserManager _currentUser;

        public string Name => "Create bank account";

        public CreateBankAccountScenario(
            IBankAccountService bankAccountService,
            ICurrentUserManager currentUser)
        {
            _bankAccountService = bankAccountService;
            _currentUser = currentUser;
        }

        public void Run()
        {
            //TODO: замечания при вводе неккоректных данных
            AnsiConsole.MarkupLine("[blue]Create bank account[/]");
            var pinCode = AnsiConsole.Ask<string>("Come up with a PIN code");
            var number = AnsiConsole.Ask<ushort>("Сome up with a number");

            try
            {
                _bankAccountService.Create(_currentUser.User.Id, number, pinCode);
            }
            catch (Exception ex)
            {
                AnsiConsole.MarkupLine("[red]Creation error bank account[/]");
                AnsiConsole.MarkupLine($"[red]{ex.Message}[/]");
                
                return;
            }

            AnsiConsole.MarkupLine("[green]Created successfully bank account[/]");
        }
    }
}

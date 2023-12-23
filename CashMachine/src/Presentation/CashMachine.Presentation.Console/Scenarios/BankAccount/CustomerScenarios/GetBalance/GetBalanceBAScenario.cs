using CashMachine.Application.Contracts.Managers;
using CashMachine.Application.Contracts.Services.BankAccounts;
using Spectre.Console;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CashMachine.Presentation.Console.Scenarios.BankAccount.CustomerScenarios.GetBalance
{
    public class GetBalanceBAScenario : IScenario
    {
        private readonly IBankAccountService _bankAccountService;
        private readonly ICurrentBankAccountManager _currentBankAccountManager;

        /// <inheritdoc />
        public string Name => "Get balance bank account";

        public GetBalanceBAScenario(
            IBankAccountService bankAccountService,
            ICurrentBankAccountManager currentBankAccountManager)
        {
            _bankAccountService = bankAccountService;
            _currentBankAccountManager = currentBankAccountManager;
        }

        /// <inheritdoc />
        public void Run()
        {
            AnsiConsole.MarkupLine("[blue]Balance bank account[/]");
            decimal balance;

            try
            {
                balance = _bankAccountService.GetBalance(_currentBankAccountManager.BankAccount.Id);
            }
            catch (Exception ex)
            {
                AnsiConsole.MarkupLine("[red]Error get bank balance account[/]");
                AnsiConsole.MarkupLine($"[red]{ex.Message}[/]");

                return;
            }
            AnsiConsole.MarkupLine("[green]successfully received[/]");
            AnsiConsole.MarkupLine($"[white]Balance: {balance}[/]");
        }
    }
}

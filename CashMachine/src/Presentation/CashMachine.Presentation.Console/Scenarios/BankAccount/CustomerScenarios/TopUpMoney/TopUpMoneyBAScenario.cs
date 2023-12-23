using CashMachine.Application.Contracts.Managers;
using CashMachine.Application.Contracts.Services.BankAccounts;
using Spectre.Console;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CashMachine.Presentation.Console.Scenarios.BankAccount.CustomerScenarios.TopUpMoney
{
    public class TopUpMoneyBAScenario : IScenario
    {
        private readonly IBankAccountService _bankAccountService;
        private readonly ICurrentBankAccountManager _currentBankAccountManager;

        /// <inheritdoc />
        public string Name => "Top up money bank account";

        public TopUpMoneyBAScenario(
            IBankAccountService bankAccountService,
            ICurrentBankAccountManager currentBankAccountManager)
        {
            _bankAccountService = bankAccountService;
            _currentBankAccountManager = currentBankAccountManager;
        }

        /// <inheritdoc />
        public void Run()
        {
            AnsiConsole.MarkupLine("[blue]Top up money bank account[/]");
            var amount = AnsiConsole.Ask<decimal>("Enter how much should top up balance?");
            decimal currentBalance;

            try
            {
                currentBalance = _bankAccountService.TopUpMoney(_currentBankAccountManager.BankAccount.Id, amount);
            }
            catch (Exception ex)
            {
                AnsiConsole.MarkupLine("[red]Replenishment error[/]");
                AnsiConsole.MarkupLine($"[red]{ex.Message}[/]");

                return;
            }

            AnsiConsole.MarkupLine("[green]Replenishment of the balance was successfult[/]");
            AnsiConsole.MarkupLine($"[green]Your balance: {currentBalance}[/]");
        }
    }
}

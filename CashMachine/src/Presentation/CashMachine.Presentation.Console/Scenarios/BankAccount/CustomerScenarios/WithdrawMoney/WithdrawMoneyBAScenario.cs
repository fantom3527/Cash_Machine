using CashMachine.Application.Contracts.Managers;
using CashMachine.Application.Contracts.Services.BankAccounts;
using Spectre.Console;

namespace CashMachine.Presentation.Console.Scenarios.BankAccount.CustomerScenarios.WithdrawMoney
{
    public class WithdrawMoneyBAScenario : IScenario
    {
        private readonly IBankAccountService _bankAccountService;
        private readonly ICurrentBankAccountManager _currentBankAccountManager;

        /// <inheritdoc />
        public string Name => "Withdraw money bank account";

        public WithdrawMoneyBAScenario(
            IBankAccountService bankAccountService,
            ICurrentBankAccountManager currentBankAccountManager)
        {
            _bankAccountService = bankAccountService;
            _currentBankAccountManager = currentBankAccountManager;
        }

        public void Run()
        {
            AnsiConsole.MarkupLine("[blue]Withdraw money bank account[/]");
            var amount = AnsiConsole.Ask<decimal>("Enter how much should withdraw balance?");
            decimal currentBalance;

            try
            {
                currentBalance = _bankAccountService.WithdrawMoney(_currentBankAccountManager.BankAccount.Id, amount);
            }
            catch (Exception ex)
            {
                AnsiConsole.MarkupLine("[red]Withdrawal error[/]");
                AnsiConsole.MarkupLine($"[red]{ex.Message}[/]");

                return;
            }

            AnsiConsole.MarkupLine("[green]Withdrawal of the balance was successfult[/]");
            AnsiConsole.MarkupLine($"[green]Your balance: {currentBalance}[/]");
        }
    }
}

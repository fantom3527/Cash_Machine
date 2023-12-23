using CashMachine.Application.Contracts.Managers;
using CashMachine.Application.Contracts.Services.BankAccounts;
using Spectre.Console;

namespace CashMachine.Presentation.Console.Scenarios.BankAccount.CustomerScenarios.GetAllHistory
{
    public class GetAllHistoryByBAScenario : IScenario
    {
        private readonly ICurrentBankAccountManager _currentBankAccountManager;
        private readonly IBankAccountHistoryService _bankAccountHistoryService;

        /// <inheritdoc />
        public string Name => "Get all history by bank account";

        public GetAllHistoryByBAScenario(
            ICurrentBankAccountManager currentBankAccountManager,
            IBankAccountHistoryService bankAccountHistoryService)
        {
            _currentBankAccountManager = currentBankAccountManager;
            _bankAccountHistoryService = bankAccountHistoryService;
        }

        /// <inheritdoc />
        public void Run()
        {
            AnsiConsole.MarkupLine("[blue]All history by bank account[/]");

            try
            {
                var histories = _bankAccountHistoryService.GetAllByBankAccountId(_currentBankAccountManager.BankAccount.Id).ToList();

                if (histories.Any())
                {
                    var table = new Table();
                    table.AddColumn("ID");
                    table.AddColumn("Bank Account ID");
                    table.AddColumn("Method");
                    table.AddColumn("Timestamp");

                    foreach (var history in histories)
                    {
                        table.AddRow(new string[] {
                            history.Id.ToString(),
                            history.BankAccountId.ToString(),
                            history.Method.ToString(),
                            history.Ts.ToString() 
                        });
                    }

                    AnsiConsole.Render(table);
                }
                else
                {
                    AnsiConsole.MarkupLine("[yellow]No history found for the bank account[/]");

                    return;
                }

            }
            catch (Exception ex)
            {
                AnsiConsole.MarkupLine("[red]Error getting all history by bank account[/]");
                AnsiConsole.MarkupLine($"[red]{ex.Message}[/]");

                return;
            }
            AnsiConsole.MarkupLine("[green]successfully received[/]");
        }
    }
}

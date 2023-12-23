using CashMachine.Application.Contracts.Services.BankAccounts;
using Spectre.Console;

namespace CashMachine.Presentation.Console.Scenarios.BankAccount.AdminScenarios.GetAll
{
    public class GetAllBAScenario : IScenario
    {
        private readonly IBankAccountService _bankAccountService;

        /// <inheritdoc />
        public string Name => "Get all bank accounts";

        public GetAllBAScenario(IBankAccountService bankAccountService)
        {
            _bankAccountService = bankAccountService;
        }

        /// <inheritdoc />
        public void Run()
        {
            AnsiConsole.MarkupLine("[blue]All bank accounts[/]");

            try
            {
                var histories = _bankAccountService.GetAll();

                if (histories.Any())
                {
                    var table = new Table();
                    table.AddColumn("ID");
                    table.AddColumn("User Id");
                    table.AddColumn("Number");
                    table.AddColumn("Balance");
                    table.AddColumn("Actual");
                    table.AddColumn("Timestamp");

                    foreach (var history in histories)
                    {
                        table.AddRow(new string[] {
                            history.Id.ToString(),
                            history.UserId.ToString(),
                            history.Number.ToString(),
                            history.Balance.ToString(),
                            history.Actual.ToString(),
                            history.Ts.ToString()
                        });
                    }

                    AnsiConsole.Render(table);
                }
                else
                {
                    AnsiConsole.MarkupLine("[yellow]No bank accounts found[/]");

                    return;
                }

            }
            catch (Exception ex)
            {
                AnsiConsole.MarkupLine("[red]Error getting bank accounts[/]");
                AnsiConsole.MarkupLine($"[red]{ex.Message}[/]");

                return;
            }
            AnsiConsole.MarkupLine("[green]successfully received[/]");
        }
    }
}

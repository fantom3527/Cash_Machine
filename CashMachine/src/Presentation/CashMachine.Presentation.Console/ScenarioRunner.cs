using Spectre.Console;

namespace CashMachine.Presentation.Console;

public class ScenarioRunner
{
    private readonly IEnumerable<ILoginScenarioProvider> _providers;

    public ScenarioRunner(IEnumerable<ILoginScenarioProvider> providers)
    {
        _providers = providers;
    }

    public void Run()
    {
        IEnumerable<IScenario> scenarios = GetScenarios();

        AnsiConsole.Write(new FigletText("Welcome to Our Bank ATM")
            .Color(Color.Blue));

        AnsiConsole.MarkupLine("[bold green]Welcome, User! Please proceed with your card.[/]");

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

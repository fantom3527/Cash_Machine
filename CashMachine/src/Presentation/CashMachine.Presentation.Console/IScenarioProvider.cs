using System.Diagnostics.CodeAnalysis;

namespace CashMachine.Presentation.Console;

public interface IScenarioProvider
{
    bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario);
}

using System.Diagnostics.CodeAnalysis;

namespace CashMachine.Presentation.Console;

/// <summary>
/// Интерфейс, предоставляющий метод для получения сценария.
/// </summary>
public interface IScenarioProvider
{
    /// <summary>
    /// Пытается получить сценарий.
    /// </summary>
    /// <param name="scenario">Полученный сценарий, если операция выполнена успешно.</param>
    /// <returns>Значение true, если удалось получить сценарий, иначе - false.</returns>
    bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario);
}

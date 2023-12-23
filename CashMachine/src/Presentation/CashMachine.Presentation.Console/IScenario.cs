namespace CashMachine.Presentation.Console;

/// <summary>
/// Интерфейс определяющий сценарий.
/// </summary>
public interface IScenario
{
    /// <summary>
    /// Возвращает имя сценария.
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Запускает выполнение сценария.
    /// </summary>
    void Run();
}
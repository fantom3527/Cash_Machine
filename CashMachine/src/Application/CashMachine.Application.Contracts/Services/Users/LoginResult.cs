namespace CashMachine.Application.Contracts.Services.Users;

/// <summary>
/// Представляет абстрактную запись, используемую для представления результатов входа в систему.
/// </summary>
public abstract record LoginResult
{
    /// <summary>
    /// Приватный конструктор для предотвращения создания экземпляров за пределами класса.
    /// </summary>
    private LoginResult() { }

    /// <summary>
    /// Представляет результат успешного входа в систему.
    /// </summary>
    public sealed record Success : LoginResult;

    /// <summary>
    /// Представляет результат неудачного поиска (например, учетной записи).
    /// </summary>
    public sealed record NotFound : LoginResult;
}
namespace CashMachine.Application.Models.Users;

/// <summary>
/// Пользователь.
/// </summary>
public record User(Guid Id, UserRole Role, string PasswordHash, string Name, string Description, bool Actual, DateTime Ts);
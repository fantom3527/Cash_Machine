namespace CashMachine.Application.Models.BankAccounts;

/// <summary>
/// История по банковскому счету.
/// </summary>
public record BankAccountHistory(Guid Id, Guid BankAccountId, BankAccountHistoryMethod Method, string? Description, DateTime Ts);
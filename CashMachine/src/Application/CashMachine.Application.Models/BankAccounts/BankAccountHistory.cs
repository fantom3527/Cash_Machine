namespace CashMachine.Application.Models.BankAccounts;

public record BankAccountHistory(Guid Id, Guid BankAccountId, BankAccountHistoryMethod Method, string? Description, DateTime Ts);
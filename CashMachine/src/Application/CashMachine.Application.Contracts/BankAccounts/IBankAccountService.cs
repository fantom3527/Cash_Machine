using CashMachine.Application.Models.BankAccounts;

namespace CashMachine.Application.Contracts.BankAccounts
{
    public interface IBankAccountService
    {
        BankAccount Get(Guid id);
        Guid Create(BankAccount bankAccount);
        decimal GetBalance(Guid id);
        decimal WithdrawMoney(Guid id, decimal amount);
        decimal TopUpMoney(Guid id, decimal amount);
    }
}

using CashMachine.Application.Models.BankAccounts;

namespace CashMachine.Application.Abstractions.Reposituries
{
    public interface IBankAccountRepository
    {
        BankAccount GetByNumberAndPinCode(ushort number, string pinCodeHash);
        Guid Create(BankAccount bankAccount);
        decimal GetBalance(Guid id);
        decimal WithdrawMoney(Guid id, decimal amount);
        decimal TopUpMoney(Guid id, decimal amount);
    }
}

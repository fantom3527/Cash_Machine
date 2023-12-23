using CashMachine.Application.Models.BankAccounts;

namespace CashMachine.Application.Contracts.Services.BankAccounts
{
    public interface IBankAccountService
    {
        BankAccount Get(Guid id);
        void Create(Guid userId, ushort number, string pinCode);
        decimal GetBalance(Guid id);
        decimal WithdrawMoney(Guid id, decimal amount);
        decimal TopUpMoney(Guid id, decimal amount);
    }
}

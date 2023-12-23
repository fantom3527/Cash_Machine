using CashMachine.Application.Models.BankAccounts;

namespace CashMachine.Application.Abstractions.Reposituries
{
    public interface IBankAccountRepository
    {
        BankAccount GetByNumberAndPinCode(ushort number, string pinCodeHash);
        decimal GetBalance(Guid id);
        void Create(BankAccount bankAccount);
        void UpdateBalance(Guid id, decimal balance);
    }
}

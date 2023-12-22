using CashMachine.Application.Models.BankAccounts;

namespace CashMachine.Application.Abstractions.Reposituries
{
    public interface IBankAccountHistoryRepository
    {
        IEnumerable<BankAccountHistory> GetAllByBankAccountId(Guid bankAccountId);
    }
}
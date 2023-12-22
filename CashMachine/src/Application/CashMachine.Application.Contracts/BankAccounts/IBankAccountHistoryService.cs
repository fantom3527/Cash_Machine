using CashMachine.Application.Models.BankAccounts;

namespace CashMachine.Application.Contracts.BankAccounts
{
    public interface IBankAccountHistoryService
    {
        IEnumerable<BankAccountHistory> GetAllByBankAccountId(Guid bankAccountId);
    }
}

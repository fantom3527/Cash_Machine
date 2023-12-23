using CashMachine.Application.Models.BankAccounts;

namespace CashMachine.Application.Contracts.Services.BankAccounts
{
    public interface IBankAccountHistoryService
    {
        IEnumerable<BankAccountHistory> GetAllByBankAccountId(Guid bankAccountId);

    }
}

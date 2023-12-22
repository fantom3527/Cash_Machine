using CashMachine.Application.Abstractions.Reposituries;
using CashMachine.Application.Contracts.BankAccounts;
using CashMachine.Application.Models.BankAccounts;

namespace CashMachine.Application.Services.BankAccounts
{
    public class BankAccountHistoryService : IBankAccountHistoryService
    {
        private readonly IBankAccountHistoryRepository _repository;

        public BankAccountHistoryService(IBankAccountHistoryRepository repository)
            => _repository = repository;

        public IEnumerable<BankAccountHistory> GetAllByBankAccountId(Guid bankAccountId)
        {
            return _repository.GetAllByBankAccountId(bankAccountId);
        }
    }
}

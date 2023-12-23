using CashMachine.Application.Abstractions.Reposituries;
using CashMachine.Application.Contracts.Services.BankAccounts;
using CashMachine.Application.Models.BankAccounts;

namespace CashMachine.Application.Services.BankAccounts
{
    /// <inheritdoc />
    public class BankAccountHistoryService : IBankAccountHistoryService
    {
        private readonly IBankAccountHistoryRepository _repository;

        public BankAccountHistoryService(IBankAccountHistoryRepository repository)
            => _repository = repository;

        /// <inheritdoc />
        public IEnumerable<BankAccountHistory> GetAllByBankAccountId(Guid bankAccountId)
        {
            return _repository.GetAllByBankAccountId(bankAccountId);
        }
    }
}

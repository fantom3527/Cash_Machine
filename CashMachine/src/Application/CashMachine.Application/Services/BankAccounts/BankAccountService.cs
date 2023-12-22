using CashMachine.Application.Abstractions.Reposituries;
using CashMachine.Application.Contracts.BankAccounts;
using CashMachine.Application.Models.BankAccounts;

namespace CashMachine.Application.Services.BankAccounts
{
    public class BankAccountService : IBankAccountService
    {
        private readonly IBankAccountRepository _repository;

        public BankAccountService(IBankAccountRepository repository)
            => _repository = repository;

        public BankAccount Get(Guid id)
        {
            return null/*_repository.Get(id)*/;
        }
        public Guid Create(BankAccount bankAccount)
        {
            return _repository.Create(bankAccount);
        }
        public decimal GetBalance(Guid id)
        {
            return _repository.GetBalance(id);
        }
        public decimal WithdrawMoney(Guid id, decimal amount)
        {
            return _repository.WithdrawMoney(id, amount);
        }
        public decimal TopUpMoney(Guid id, decimal amount)
        {
            return _repository.TopUpMoney(id, amount);
        }
    }
}

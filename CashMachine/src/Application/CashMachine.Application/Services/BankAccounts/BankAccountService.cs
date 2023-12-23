using CashMachine.Application.Abstractions.Reposituries.Managers;
using CashMachine.Application.Common.Security;
using CashMachine.Application.Contracts.Services.BankAccounts;
using CashMachine.Application.Models.BankAccounts;

namespace CashMachine.Application.Services.BankAccounts
{
    public class BankAccountService : IBankAccountService
    {
        private readonly IRepositoryManager _repositoryManager;

        public BankAccountService(IRepositoryManager repositoryManager)
            => _repositoryManager = repositoryManager;

        //TODO: удалить
        public BankAccount Get(Guid id)
        {
            return null/*_repository.Get(id)*/;
        }

        public void Create(Guid userId, ushort number, string pinCode)
        {
            var bankAccount = CreateBankAccount(userId, number, pinCode);

            _repositoryManager.BankAccountRepository.Create(bankAccount);
            CreateBankAccountHistory(bankAccount.Id, BankAccountHistoryMethod.add);
        }

        public decimal GetBalance(Guid id)
        {
            return _repositoryManager.BankAccountRepository.GetBalance(id);
        }

        public decimal WithdrawMoney(Guid id, decimal amount)
        {
            var balance = _repositoryManager.BankAccountRepository.GetBalance(id);
            
            var value = balance - amount;
            if (value < 0)
            {
                throw new InvalidOperationException("Недостаточно средств на счете для выполнения операции.");
            }

            _repositoryManager.BankAccountRepository.UpdateBalance(id, value);
            CreateBankAccountHistory(id, BankAccountHistoryMethod.withdrawbalance);

            return value;
        }

        public decimal TopUpMoney(Guid id, decimal amount)
        {
            var balance = _repositoryManager.BankAccountRepository.GetBalance(id);
            var value = balance + amount;
            // Для случая, когда в amount удалось записать отрицательное число.
            if (value < 0)
            {
                throw new InvalidOperationException("Недостаточно средств на счете для выполнения операции.");
            }

            _repositoryManager.BankAccountRepository.UpdateBalance(id, value);
            CreateBankAccountHistory(id, BankAccountHistoryMethod.topupbalance);

            return value;
        }

        private void CreateBankAccountHistory(Guid bankAccountId, BankAccountHistoryMethod historyMethod, string? desctiption = null)
        {
            var bankAccountHistory = new BankAccountHistory
            (
                Id: Guid.NewGuid(),
                BankAccountId: bankAccountId,
                Method: historyMethod,
                Description: desctiption,
                Ts: DateTime.Now
            );

            _repositoryManager.BankAccountHistoryRepository.Create(bankAccountHistory);
        }

        private BankAccount CreateBankAccount(Guid userId, ushort number, string pinCode)
        {
            var pinCodeHash = PasswordHasher.CreateHash(pinCode);

            return new BankAccount
                   (
                       Id: Guid.NewGuid(),
                       UserId: userId,
                       Number: number,
                       PinCodeHash: pinCodeHash,
                       Balance: decimal.Zero,
                       Actual: true,
                       Ts: DateTime.Now
                   );
        }
    }
}

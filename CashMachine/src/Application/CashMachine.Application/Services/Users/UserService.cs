using CashMachine.Application.Abstractions.Reposituries.Managers;
using CashMachine.Application.Common.Security;
using CashMachine.Application.Contracts.Services.Users;
using CashMachine.Application.Managers;

namespace CashMachine.Application.Services.Users
{
    /// <inheritdoc />
    public class UserService : IUserService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly CurrentUserManager _currentUserManager;
        private readonly CurrentBankAccountManager _currentBankAccountManager;

        public UserService(
            IRepositoryManager repositoryManager, 
            CurrentUserManager currentUserManager,
            CurrentBankAccountManager currentBankAccountManager)
        {
            _repositoryManager = repositoryManager;
            _currentUserManager = currentUserManager;
            _currentBankAccountManager = currentBankAccountManager;
        }

        /// <inheritdoc />
        public LoginResult LoginAsAdmin(string systemPassword)
        {
            var systemPasswordHash = PasswordHasher.CreateHash(systemPassword);

            var user = _repositoryManager.UserRepository.GetUserByPassword(systemPasswordHash);
            if (user is null)
            {
                return new LoginResult.NotFound();
            }
            _currentUserManager.User = user;

            return new LoginResult.Success();
        }

        /// <inheritdoc />
        public LoginResult LoginAsCustomer(ushort bankAccountNumber, string bankAccountPassword)
        {
            var bankAccountPasswordHash = PasswordHasher.CreateHash(bankAccountPassword);

            var bankAccount = _repositoryManager.BankAccountRepository.GetByNumberAndPinCode(bankAccountNumber, bankAccountPasswordHash);
            if (bankAccount is null)
            {
                return new LoginResult.NotFound();
            }
            _currentBankAccountManager.BankAccount = bankAccount;

            var user = _repositoryManager.UserRepository.Get(bankAccount.UserId);
            if (user is null)
            {
                return new LoginResult.NotFound();
            }
            _currentUserManager.User = user;

            return new LoginResult.Success();
        }
    }
}

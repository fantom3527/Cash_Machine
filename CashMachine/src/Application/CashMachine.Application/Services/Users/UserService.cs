using CashMachine.Application.Abstractions.Reposituries.Managers;
using CashMachine.Application.Contracts.Users;
using CashMachine.Application.Managers;
using CashMachine.Application.Models.BankAccounts;
using System.Security.Cryptography;
using System.Text;

namespace CashMachine.Application.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly CurrentUserManager _currentUserManager;

        public UserService(IRepositoryManager repositoryManager, CurrentUserManager currentUserManager)
        {
            _repositoryManager = repositoryManager;
            _currentUserManager = currentUserManager;
        }

        public LoginResult LoginAsAdmin(string systemPassword)
        {
            var systemPasswordHash = CreateHash(systemPassword);

            var user = _repositoryManager.UserRepository.GetUserByPassword(systemPasswordHash);
            if (user is null)
            {
                return new LoginResult.NotFound();
            }

            _currentUserManager.User = user;

            return new LoginResult.Success();
        }

        public BankAccount LoginAsCustomer(ushort bankAccountNumber, string bankAccountPassword)
        {
            var bankAccountPasswordHash = CreateHash(bankAccountPassword);
            var bankAccount = _repositoryManager.BankAccountRepository.GetByNumberAndPinCode(bankAccountNumber, bankAccountPasswordHash);

            var user = _repositoryManager.UserRepository.GetUserByBankAccount(bankAccount.Id);
            _currentUserManager.User = user;

            return bankAccount;
        }

        private string CreateHash(string value)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Преобразуем строку в массив байтов и вычисляем хэш
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(value));

                // Преобразуем массив байтов в строку в шестнадцатеричном формате
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }
    }
}

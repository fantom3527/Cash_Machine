using CashMachine.Application.Models.BankAccounts;

namespace CashMachine.Application.Contracts.Services.Users
{
    /// <summary>
    /// Сервис для операций, связанных с пользователями.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Позволяет пользователю войти в учетную запись как клиент.
        /// </summary>
        /// <param name="bankAccountNumber">Номер банковского счета клиента.</param>
        /// <param name="bankAccountPassword">Пароль банковского счета клиента.</param>
        /// <returns>Результат входа в систему в качестве клиента.</returns>
        LoginResult LoginAsCustomer(ushort bankAccountNumber, string bankAccountPassword);

        /// <summary>
        /// Позволяет пользователю войти в учетную запись как администратор.
        /// </summary>
        /// <param name="systemPassword">Пароль системы.</param>
        /// <returns>Результат входа в систему в качестве администратора.</returns>
        LoginResult LoginAsAdmin(string systemPassword);
    }
}

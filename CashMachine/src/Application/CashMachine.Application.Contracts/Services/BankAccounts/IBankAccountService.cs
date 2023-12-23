using CashMachine.Application.Models.BankAccounts;

namespace CashMachine.Application.Contracts.Services.BankAccounts
{
    /// <summary>
    /// Сервис для работы с банковскими счетами.
    /// </summary>
    public interface IBankAccountService
    {
        /// <summary>
        /// Получает все банковские счета.
        /// </summary>
        IEnumerable<BankAccount> GetAll();

        /// <summary>
        /// Создает новый банковский счет для указанного пользователя.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя, для которого создается счет.</param>
        /// <param name="number">Номер нового банковского счета.</param>
        /// <param name="pinCode">Пин-код нового банковского счета.</param>
        void Create(Guid userId, ushort number, string pinCode);

        /// <summary>
        /// Получает текущий баланс банковского счета по его идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор банковского счета.</param>
        decimal GetBalance(Guid id);

        /// <summary>
        /// Снимает указанную сумму с баланса банковского счета.
        /// </summary>
        /// <param name="id">Идентификатор банковского счета.</param>
        /// <param name="amount">Сумма для снятия.</param>
        decimal WithdrawMoney(Guid id, decimal amount);

        /// <summary>
        /// Пополняет баланс банковского счета на указанную сумму.
        /// </summary>
        /// <param name="id">Идентификатор банковского счета.</param>
        /// <param name="amount">Сумма для пополнения.</param>
        decimal TopUpMoney(Guid id, decimal amount);
    }
}

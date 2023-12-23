using CashMachine.Application.Models.BankAccounts;

namespace CashMachine.Application.Abstractions.Reposituries
{
    /// <summary>
    /// Определяет методы для работы с репозиторием банковских счетов.
    /// </summary>
    public interface IBankAccountRepository
    {
        /// <summary>
        /// Получает все банковские счета.
        /// </summary>
        /// <returns>Коллекция всех банковских счетов.</returns>
        IEnumerable<BankAccount> GetAll();

        /// <summary>
        /// Получает банковский счет по номеру и хэшу пин-кода.
        /// </summary>
        /// <param name="number">Номер банковского счета.</param>
        /// <param name="pinCodeHash">Хэш пин-кода.</param>
        /// <returns>Банковский счет, соответствующий указанным параметрам.</returns>
        BankAccount GetByNumberAndPinCode(ushort number, string pinCodeHash);

        /// <summary>
        /// Получает текущий баланс банковского счета по его идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор банковского счета.</param>
        /// <returns>Текущий баланс банковского счета.</returns>
        decimal GetBalance(Guid id);

        /// <summary>
        /// Создает новый банковский счет.
        /// </summary>
        /// <param name="bankAccount">Детали нового банковского счета.</param>
        void Create(BankAccount bankAccount);

        /// <summary>
        /// Обновляет баланс банковского счета по его идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор банковского счета.</param>
        /// <param name="balance">Новый баланс.</param>
        void UpdateBalance(Guid id, decimal balance);
    }
}

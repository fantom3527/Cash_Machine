using CashMachine.Application.Models.BankAccounts;

namespace CashMachine.Application.Abstractions.Reposituries
{
    /// <summary>
    /// Интерфейс, определяющий методы для работы с репозиторием истории операций банковских счетов.
    /// </summary>
    public interface IBankAccountHistoryRepository
    {
        /// <summary>
        /// Получает все записи истории операций банковского счета по его идентификатору.
        /// <param name="bankAccountId">Идентификатор банковского счета.</param>
        /// <returns>Коллекция записей истории операций банковского счета.</returns>
        IEnumerable<BankAccountHistory> GetAllByBankAccountId(Guid bankAccountId);

        /// <summary>
        /// Создает новую запись в репозитории истории операций банковского счета.
        /// </summary>
        void Create(BankAccountHistory bankAccountHistory);
    }
}
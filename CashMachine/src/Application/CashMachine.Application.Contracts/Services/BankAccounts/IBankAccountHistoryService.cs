using CashMachine.Application.Models.BankAccounts;

namespace CashMachine.Application.Contracts.Services.BankAccounts
{
    /// <summary>
    /// Сервис для работы с историей банковских счетов.
    /// </summary>
    public interface IBankAccountHistoryService
    {
        /// <summary>
        /// Получает все записи истории операций банковского счета по его идентификатору.
        /// </summary>
        /// <param name="bankAccountId">Идентификатор банковского счета.</param>
        IEnumerable<BankAccountHistory> GetAllByBankAccountId(Guid bankAccountId);
    }
}

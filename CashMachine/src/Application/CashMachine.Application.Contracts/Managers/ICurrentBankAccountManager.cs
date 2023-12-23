using CashMachine.Application.Models.BankAccounts;

namespace CashMachine.Application.Contracts.Managers
{
    /// <summary>
    /// Предоставляет доступ к текущему банковскому счету.
    /// </summary>
    public interface ICurrentBankAccountManager
    {
        /// <summary>
        /// Возвращает текущий банковский счет.
        /// </summary>
        BankAccount? BankAccount { get; }
    }
}

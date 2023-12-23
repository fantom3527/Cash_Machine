namespace CashMachine.Application.Abstractions.Reposituries.Managers
{
    /// <summary>
    /// Предоставляет доступ к репозиториям банковских счетов, их истории операций и пользователям.
    /// </summary>
    public interface IRepositoryManager
    {
        /// <summary>
        /// Получает доступ к репозиторию банковских счетов.
        /// </summary>
        IBankAccountRepository BankAccountRepository { get; }

        /// <summary>
        /// Получает доступ к репозиторию истории операций с банковскими счетами.
        /// </summary>
        IBankAccountHistoryRepository BankAccountHistoryRepository { get; }

        /// <summary>
        /// Получает доступ к репозиторию пользователей.
        /// </summary>
        IUserRepository UserRepository { get; }
    }
}

namespace CashMachine.Application.Abstractions.Reposituries.Managers
{
    public interface IRepositoryManager
    {
        IBankAccountRepository BankAccountRepository { get; }
        IBankAccountHistoryRepository BankAccountHistoryRepository { get; }
        IUserRepository UserRepository { get; }
    }
}

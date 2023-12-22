namespace CashMachine.Application.Abstractions.Reposituries.Managers
{
    public interface IRepositoryManager
    {
        IBankAccountRepository BankAccountRepository { get; }
        IUserRepository UserRepository { get; }
    }
}

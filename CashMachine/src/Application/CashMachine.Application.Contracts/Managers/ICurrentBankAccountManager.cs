using CashMachine.Application.Models.BankAccounts;

namespace CashMachine.Application.Contracts.Managers
{
    public interface ICurrentBankAccountManager
    {
        //TODO: Добавить здесь Dto
        BankAccount? BankAccount { get; }
    }
}

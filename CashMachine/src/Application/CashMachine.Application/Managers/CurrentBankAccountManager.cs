using CashMachine.Application.Contracts.Managers;
using CashMachine.Application.Models.BankAccounts;

namespace CashMachine.Application.Managers
{
    public class CurrentBankAccountManager : ICurrentBankAccountManager
    {
        //TODO: Оставить только поле Id
        public BankAccount? BankAccount { get; set; }
    }
}

using CashMachine.Application.Contracts.Managers;
using CashMachine.Application.Models.BankAccounts;

namespace CashMachine.Application.Managers
{
    /// <inheritdoc />
    public class CurrentBankAccountManager : ICurrentBankAccountManager
    {
        /// <inheritdoc />
        public BankAccount? BankAccount { get; set; }
    }
}

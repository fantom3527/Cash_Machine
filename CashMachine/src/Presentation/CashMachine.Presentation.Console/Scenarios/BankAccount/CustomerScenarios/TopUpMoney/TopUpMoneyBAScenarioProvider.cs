using CashMachine.Application.Contracts.Managers;
using CashMachine.Application.Contracts.Services.BankAccounts;
using System.Diagnostics.CodeAnalysis;

namespace CashMachine.Presentation.Console.Scenarios.BankAccount.CustomerScenarios.TopUpMoney
{
    public class TopUpMoneyBAScenarioProvider : ICustomerScenarioProvider
    {
        private readonly IBankAccountService _service;
        private readonly ICurrentUserManager _currentUser;
        private readonly ICurrentBankAccountManager _currentBankAccountManager;

        public TopUpMoneyBAScenarioProvider(
            IBankAccountService service,
            ICurrentUserManager currentUser,
            ICurrentBankAccountManager currentBankAccountManager)
        {
            _service = service;
            _currentUser = currentUser;
            _currentBankAccountManager = currentBankAccountManager;
        }
        public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
        {
            if (_currentUser.User is null)
            {
                scenario = null;
                return false;
            }

            scenario = new TopUpMoneyBAScenario(_service, _currentBankAccountManager);
            return true;
        }
    }
}

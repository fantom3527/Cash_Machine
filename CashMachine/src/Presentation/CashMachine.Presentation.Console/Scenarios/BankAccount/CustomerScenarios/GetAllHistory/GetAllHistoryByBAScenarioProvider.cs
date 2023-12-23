using CashMachine.Application.Contracts.Managers;
using CashMachine.Application.Contracts.Services.BankAccounts;
using System.Diagnostics.CodeAnalysis;

namespace CashMachine.Presentation.Console.Scenarios.BankAccount.CustomerScenarios.GetAllHistory
{
    public class GetAllHistoryByBAScenarioProvider : ICustomerScenarioProvider
    {
        private readonly IBankAccountHistoryService _service;
        private readonly ICurrentBankAccountManager _currentBankAccountManager;
        private readonly ICurrentUserManager _currentUser;

        public GetAllHistoryByBAScenarioProvider(
            IBankAccountHistoryService service,
            ICurrentBankAccountManager currentBankAccountManager,
            ICurrentUserManager currentUser)
        {
            _service = service;
            _currentBankAccountManager = currentBankAccountManager;
            _currentUser = currentUser;
        }

        /// <inheritdoc />
        public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
        {
            if (_currentUser.User is null)
            {
                scenario = null;
                return false;
            }

            scenario = new GetAllHistoryByBAScenario(_currentBankAccountManager, _service);
            return true;
        }
    }
}

using CashMachine.Application.Contracts.Managers;
using CashMachine.Application.Contracts.Services.BankAccounts;
using System.Diagnostics.CodeAnalysis;

namespace CashMachine.Presentation.Console.Scenarios.BankAccount.CustomerScenarios.Create
{
    public class CreateBankAccountScenarioProvider : ICustomerScenarioProvider
    {
        private readonly IBankAccountService _service;
        private readonly ICurrentUserManager _currentUser;

        public CreateBankAccountScenarioProvider(
            IBankAccountService service,
            ICurrentUserManager currentUser)
        {
            _service = service;
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

            scenario = new CreateBankAccountScenario(_service, _currentUser);
            return true;
        }
    }
}

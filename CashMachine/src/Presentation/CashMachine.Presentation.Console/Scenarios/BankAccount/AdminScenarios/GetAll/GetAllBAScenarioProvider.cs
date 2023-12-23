using CashMachine.Application.Contracts.Managers;
using CashMachine.Application.Contracts.Services.BankAccounts;
using System.Diagnostics.CodeAnalysis;

namespace CashMachine.Presentation.Console.Scenarios.BankAccount.AdminScenarios.GetAll
{
    internal class GetAllBAScenarioProvider : IAdminScenarioProvider
    {
        private readonly IBankAccountService _service;
        private readonly ICurrentUserManager _currentUser;

        public GetAllBAScenarioProvider(
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

            scenario = new GetAllBAScenario(_service);
            return true;
        }
    }
}

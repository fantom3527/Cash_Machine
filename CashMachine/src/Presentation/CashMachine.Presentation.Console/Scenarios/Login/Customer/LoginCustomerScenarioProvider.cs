using CashMachine.Application.Contracts.Managers;
using CashMachine.Application.Contracts.Services.Users;
using System.Diagnostics.CodeAnalysis;

namespace CashMachine.Presentation.Console.Scenarios.Login.Customer
{
    public class LoginCustomerScenarioProvider : ILoginScenarioProvider
    {
        private readonly IEnumerable<ICustomerScenarioProvider> _providers;
        private readonly IUserService _service;
        private readonly ICurrentUserManager _currentUser;

        public LoginCustomerScenarioProvider(
            IEnumerable<ICustomerScenarioProvider> providers,
            IUserService service,
            ICurrentUserManager currentUser)
        {
            _providers = providers;
            _service = service;
            _currentUser = currentUser;
        }

        /// <inheritdoc />
        public bool TryGetScenario(
            [NotNullWhen(true)] out IScenario? scenario)
        {
            if (_currentUser.User is not null)
            {
                scenario = null;
                return false;
            }

            scenario = new LoginCustomerScenario(_providers, _service);
            return true;
        }
    }
}

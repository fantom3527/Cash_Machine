using CashMachine.Application.Contracts.Managers;
using CashMachine.Application.Contracts.Services.Users;
using System.Diagnostics.CodeAnalysis;

namespace CashMachine.Presentation.Console.Scenarios.Login.Admin
{
    public class LoginAdminScenarioProvider : ILoginScenarioProvider
    {
        private readonly IEnumerable<IAdminScenarioProvider> _provider;
        private readonly IUserService _service;
        private readonly ICurrentUserManager _currentUser;

        public LoginAdminScenarioProvider(
            IEnumerable<IAdminScenarioProvider> provider,
            IUserService service,
            ICurrentUserManager currentUser)
        {
            _provider = provider;
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

            scenario = new LoginAdminScenario(_provider, _service);
            return true;
        }
    }
}

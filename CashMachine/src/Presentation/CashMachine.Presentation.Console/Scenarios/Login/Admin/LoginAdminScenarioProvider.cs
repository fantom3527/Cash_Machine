using CashMachine.Application.Contracts.Managers;
using CashMachine.Application.Contracts.Users;
using System.Diagnostics.CodeAnalysis;

namespace CashMachine.Presentation.Console.Scenarios.Login.Admin
{
    public class LoginAdminScenarioProvider : IScenarioProvider
    {
        private readonly IUserService _service;
        private readonly ICurrentUserManager _currentUser;

        public LoginAdminScenarioProvider(
            IUserService service,
            ICurrentUserManager currentUser)
        {
            _service = service;
            _currentUser = currentUser;
        }

        public bool TryGetScenario(
            [NotNullWhen(true)] out IScenario? scenario)
        {
            if (_currentUser.User is not null)
            {
                scenario = null;
                return false;
            }

            scenario = new LoginAdminScenario(_service);
            return true;
        }
    }
}

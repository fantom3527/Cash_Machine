using CashMachine.Application.Contracts.Services.BankAccounts;

namespace CashMachine.Presentation.Console.Scenarios.BankAccount.AdminScenarios.GetAll
{
    public class GetAllBAScenario : IScenario
    {
        private readonly IBankAccountService _bankAccountService;
        public string Name => "Get all bank account";

        public GetAllBAScenario(IBankAccountService bankAccountService)
        {
            _bankAccountService = bankAccountService;
        }

        public void Run()
        {

            //TODO: вставить здесь получение
            throw new NotImplementedException();
        }
    }
}

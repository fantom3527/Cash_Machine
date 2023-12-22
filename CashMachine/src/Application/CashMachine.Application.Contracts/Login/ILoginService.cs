using CashMachine.Application.Contracts.Users;

namespace CashMachine.Application.Contracts.Login;

public interface ILoginService
{
    LoginResult LoginAsCustomer(ushort bankAccountNumber, string bankAccountPassword);
    LoginResult LoginAsAdmin(string systemPassword);
}


using CashMachine.Application.Models.BankAccounts;

namespace CashMachine.Application.Contracts.Services.Users
{
    public interface IUserService
    {
        LoginResult LoginAsCustomer(ushort bankAccountNumber, string bankAccountPassword);
        LoginResult LoginAsAdmin(string systemPassword);
    }
}

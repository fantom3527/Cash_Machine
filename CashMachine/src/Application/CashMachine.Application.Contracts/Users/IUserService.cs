using CashMachine.Application.Models.BankAccounts;

namespace CashMachine.Application.Contracts.Users
{
    public interface IUserService
    {
        BankAccount LoginAsCustomer(ushort bankAccountNumber, string bankAccountPassword);
        LoginResult LoginAsAdmin(string systemPassword);
    }
}

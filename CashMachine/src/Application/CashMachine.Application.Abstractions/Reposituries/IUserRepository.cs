using CashMachine.Application.Models.Users;

namespace CashMachine.Application.Abstractions.Reposituries
{
    public interface IUserRepository
    {
        User? GetUserByPassword(string password);
        User? Get(Guid id);
    }
}

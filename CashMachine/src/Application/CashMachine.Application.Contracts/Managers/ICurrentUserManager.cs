using CashMachine.Application.Models.Users;

namespace CashMachine.Application.Contracts.Managers
{
    public interface ICurrentUserManager
    {
        User? User { get; }
    }
}

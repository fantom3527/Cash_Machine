using CashMachine.Application.Contracts.Managers;
using CashMachine.Application.Models.Users;

namespace CashMachine.Application.Managers
{
    public class CurrentUserManager : ICurrentUserManager
    {
        public User? User { get; set; }
    }
}

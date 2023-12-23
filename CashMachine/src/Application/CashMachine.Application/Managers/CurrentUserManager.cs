using CashMachine.Application.Contracts.Managers;
using CashMachine.Application.Models.Users;

namespace CashMachine.Application.Managers
{
    /// <inheritdoc />
    public class CurrentUserManager : ICurrentUserManager
    {
        /// <inheritdoc />
        public User? User { get; set; }
    }
}

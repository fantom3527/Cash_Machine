using CashMachine.Application.Models.Users;

namespace CashMachine.Application.Contracts.Managers
{
    /// <summary>
    /// Предоставляет доступ к текущему пользователю.
    /// </summary>
    public interface ICurrentUserManager
    {
        /// <summary>
        /// Возвращает текущего пользователя.
        /// </summary>
        User? User { get; }
    }
}

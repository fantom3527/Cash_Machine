using CashMachine.Application.Models.Users;

namespace CashMachine.Application.Abstractions.Reposituries
{
    /// <summary>
    /// Для работы с репозиторием пользователей.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Получает пользователя по паролю.
        /// </summary>
        /// <param name="password">Пароль пользователя.</param>
        /// <returns>Пользователь, соответствующий указанному паролю.</returns>
        User? GetUserByPassword(string passwordHash);

        /// <summary>
        /// Получает пользователя по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        /// <returns>Пользователь с указанным идентификатором.</returns>
        User? Get(Guid id);
    }
}

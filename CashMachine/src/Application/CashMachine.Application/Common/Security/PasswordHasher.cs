using System.Security.Cryptography;
using System.Text;

namespace CashMachine.Application.Common.Security
{
    /// <summary>
    /// Предоставляет методы для хэширования паролей.
    /// </summary>
    public static class PasswordHasher
    {
        // <summary>
        /// Создает хэш для указанной строки.
        /// </summary>
        /// <param name="value">Исходная строка, для которой требуется создать хэш.</param>
        /// <returns>Хэш в шестнадцатеричном формате.</returns>
        public static string CreateHash(string value)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Преобразуем строку в массив байтов и вычисляем хэш
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(value));

                // Преобразуем массив байтов в строку в шестнадцатеричном формате
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }
    }
}

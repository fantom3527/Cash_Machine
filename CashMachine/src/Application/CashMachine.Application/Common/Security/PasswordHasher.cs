using System.Security.Cryptography;
using System.Text;

namespace CashMachine.Application.Common.Security
{
    internal static class PasswordHasher
    {
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

using CashMachine.Application.Abstractions.Reposituries;
using CashMachine.Application.Models.BankAccounts;
using CashMachine.Application.Models.Users;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Npgsql;

namespace CashMachine.Infrastructure.DataAccess.Repositories
{
    public class BankAccountHistoryRepository : IBankAccountHistoryRepository
    {
        private readonly IPostgresConnectionProvider _connectionProvider;

        public BankAccountHistoryRepository(IPostgresConnectionProvider connectionProvider)
            => _connectionProvider = connectionProvider;

        public IEnumerable<BankAccountHistory> GetAllByBankAccountId(Guid bankAccountId)
        {
            const string sql = @"
                select id, bank_account_id, bankAccountHistoryMethodId, string Name, string Desctiption, DateTime Ts
                from bank_account_history
                    inner join bank_account_history_method
                where id = :bankAccountId;
                ";

            //TODO: проверить @

            var connection = _connectionProvider
                .GetConnectionAsync(default)
                .GetAwaiter()
                .GetResult();

            using var command = new NpgsqlCommand(sql, connection)
                .AddParameter("bankAccountId", bankAccountId);
            using var reader = command.ExecuteReader();

            //if (reader.Read() is false)
            //    return null;

            while (reader.Read())
            {
                yield return new BankAccountHistory(
                    reader.GetGuid(0),
                    reader.GetGuid(1),
                    reader.GetFieldValue<BankAccountHistoryMethod>(2),
                    reader.GetString(3),
                    reader.GetString(4),
                    reader.GetDateTime(5)
                    );
            }
        }
    }
}

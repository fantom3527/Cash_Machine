using CashMachine.Application.Abstractions.Reposituries;
using CashMachine.Application.Models.BankAccounts;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Npgsql;

namespace CashMachine.Infrastructure.DataAccess.Repositories
{
    /// <inheritdoc />
    public class BankAccountHistoryRepository : IBankAccountHistoryRepository
    {
        private readonly IPostgresConnectionProvider _connectionProvider;

        public BankAccountHistoryRepository(IPostgresConnectionProvider connectionProvider)
            => _connectionProvider = connectionProvider;

        /// <inheritdoc />
        public IEnumerable<BankAccountHistory> GetAllByBankAccountId(Guid bankAccountId)
        {
            const string sql = @"
                select id, bank_account_id, method, description, ts
                from bank_account_history
                where bank_account_id = :bankAccountId;
                ";

            var connection = _connectionProvider
                .GetConnectionAsync(default)
                .GetAwaiter()
                .GetResult();

            using var command = new NpgsqlCommand(sql, connection)
                .AddParameter("bankAccountId", bankAccountId);
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                yield return new BankAccountHistory(
                    reader.GetGuid(0),
                    reader.GetGuid(1),
                    reader.GetFieldValue<BankAccountHistoryMethod>(2),
                    reader.IsDBNull(3) ? null : reader.GetString(3),
                    reader.GetDateTime(4)
                    );
            }
        }

        /// <inheritdoc />
        public void Create(BankAccountHistory bankAccountHistory)
        {
            const string sql = @"
            INSERT INTO bank_account_history(
	        id, bank_account_id, method, description, ts)
	        VALUES (:id, :bank_account_id, :method, :description, :ts);
            ";

            var connection = _connectionProvider
                .GetConnectionAsync(default)
                .GetAwaiter()
                .GetResult();

            using var command = new NpgsqlCommand(sql, connection)
                .AddParameter("id", bankAccountHistory.Id)
                .AddParameter("bank_account_id", bankAccountHistory.BankAccountId)
                .AddParameter("method", bankAccountHistory.Method)
                .AddParameter("description", bankAccountHistory.Description)
                .AddParameter("ts", bankAccountHistory.Ts);

            command.ExecuteNonQuery();
        }
    }
}

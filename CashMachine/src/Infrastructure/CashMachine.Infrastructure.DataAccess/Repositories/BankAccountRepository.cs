using CashMachine.Application.Abstractions.Reposituries;
using CashMachine.Application.Models.BankAccounts;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Npgsql;

namespace CashMachine.Infrastructure.DataAccess.Repositories
{
    public class BankAccountRepository : IBankAccountRepository
    {
        private readonly IPostgresConnectionProvider _connectionProvider;
        public BankAccountRepository(IPostgresConnectionProvider connectionProvider)
            => _connectionProvider = connectionProvider;

        public BankAccount GetByNumberAndPinCode(ushort number, string pinCodeHash)
        {
            const string sql = @"
            SELECT id, 
                   user_id, 
                   pin_code_hash, 
                   ""number"", 
                   balance, 
                   actual, 
                   ts
	        FROM ""bank_account""
            where pin_code_hash = :pin_code_hash
                  AND ""number"" = :number
            LIMIT 1;
            ";

            var connection = _connectionProvider
                .GetConnectionAsync(default)
                .GetAwaiter()
                .GetResult();

            using var command = new NpgsqlCommand(sql, connection)
                .AddParameter("pin_code_hash", pinCodeHash)
                .AddParameter("number", Convert.ToInt16(number));

            using var reader = command.ExecuteReader();

            if (reader.Read() is false)
                return null;

            return new BankAccount(
                Id: reader.GetGuid(0),
                UserId: reader.GetGuid(1),
                PinCodeHash: reader.GetString(2),
                Number: (ushort)reader.GetInt16(3),
                Balance: reader.GetDecimal(4),
                Actual: reader.GetBoolean(5),
                Ts: reader.GetDateTime(6)
                );
        }

        public void Create(BankAccount bankAccount)
        {
            //TODO: отследить exception
            const string sql = @"
            INSERT INTO bank_account(
	        id, user_id, pin_code_hash, ""number"", balance, actual, ts)
	        VALUES (:id, :user_id, :pin_code_hash, :number, :balance, :actual, :ts);
            ";

            var connection = _connectionProvider
                .GetConnectionAsync(default)
                .GetAwaiter()
                .GetResult();

            using var command = new NpgsqlCommand(sql, connection)
                .AddParameter("id", bankAccount.Id)
                .AddParameter("user_id", bankAccount.UserId)
                .AddParameter("pin_code_hash", bankAccount.PinCodeHash)
                .AddParameter("number", Convert.ToInt16(bankAccount.Number))
                .AddParameter("balance", bankAccount.Balance)
                .AddParameter("actual", bankAccount.Actual)
                .AddParameter("ts", bankAccount.Ts);

            command.ExecuteNonQuery();
        }

        public decimal GetBalance(Guid id)
        {
            const string sql = @"
            SELECT balance
	        FROM ""bank_account""
            where id = :id
            LIMIT 1;
            ";

            var connection = _connectionProvider
                .GetConnectionAsync(default)
                .GetAwaiter()
                .GetResult();

            using var command = new NpgsqlCommand(sql, connection)
            .AddParameter("id", id);

            using var reader = command.ExecuteReader();

            //TODO: заменить на exception
            if (reader.Read() is false)
                return decimal.Zero;

            return reader.GetDecimal(0);
        }

        public void UpdateBalance(Guid id, decimal balance)
        {
            //TODO: отследить exception
            const string sql = @"
            UPDATE bank_account
	        SET balance = :balance
	        WHERE id = :id;
            ";

            var connection = _connectionProvider
                .GetConnectionAsync(default)
                .GetAwaiter()
                .GetResult();

            using var command = new NpgsqlCommand(sql, connection)
                .AddParameter("id", id)
                .AddParameter("balance", balance);

            command.ExecuteNonQuery();
        }
    }
}

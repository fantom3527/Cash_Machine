using CashMachine.Application.Abstractions.Reposituries;
using CashMachine.Application.Models.Users;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Npgsql;

namespace CashMachine.Infrastructure.DataAccess.Repositories
{
    /// <inheritdoc />
    public class UserRepository : IUserRepository
    {
        private readonly IPostgresConnectionProvider _connectionProvider;
        public UserRepository(IPostgresConnectionProvider connectionProvider)
            => _connectionProvider = connectionProvider;

        /// <inheritdoc />
        public User? Get(Guid id)
        {
            const string sql = @"
            select id,
                   role,
                   password_hash,
                   name,
                   description,
                   actual,
                   ts
            from ""user""
            where id = :id;
            ";

            var connection = _connectionProvider
                .GetConnectionAsync(default)
                .GetAwaiter()
                .GetResult();

            using var command = new NpgsqlCommand(sql, connection)
                .AddParameter("id", id);

            using var reader = command.ExecuteReader();

            if (reader.Read() is false)
                return null;

            return new User(
                Id: reader.GetGuid(0),
                Role: reader.GetFieldValue<UserRole>(1),
                PasswordHash: reader.GetString(2),
                Name: reader.GetString(3),
                Description: reader.GetString(4),
                Actual: reader.GetBoolean(5),
                Ts: reader.GetDateTime(6)
                );
        }

        /// <inheritdoc />
        public User? GetUserByPassword(string passwordHash)
        {
            const string sql = @"
            select id,
                   role,
                   password_hash,
                   name,
                   description,
                   actual,
                   ts
            from ""user""
            where password_hash = :passwordHash;
            ";

            var connection = _connectionProvider
                .GetConnectionAsync(default)
                .GetAwaiter()
                .GetResult();

            using var command = new NpgsqlCommand(sql, connection)
                .AddParameter("passwordHash", passwordHash);

            using var reader = command.ExecuteReader();

            if (reader.Read() is false)
                return null;

            return new User(
                Id: reader.GetGuid(0),
                Role: reader.GetFieldValue<UserRole>(1),
                PasswordHash: reader.GetString(2),
                Name: reader.GetString(3),
                Description: reader.GetString(4),
                Actual: reader.GetBoolean(5),
                Ts: reader.GetDateTime(6)
                );
        }
    }
}

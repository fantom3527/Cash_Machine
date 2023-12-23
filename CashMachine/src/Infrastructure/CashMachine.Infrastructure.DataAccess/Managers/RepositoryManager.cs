using CashMachine.Application.Abstractions.Reposituries;
using CashMachine.Application.Abstractions.Reposituries.Managers;
using CashMachine.Infrastructure.DataAccess.Repositories;
using Itmo.Dev.Platform.Postgres.Connection;

namespace CashMachine.Infrastructure.DataAccess.Managers
{
    /// <inheritdoc />
    public class RepositoryManager : IRepositoryManager
    {
        private readonly IPostgresConnectionProvider _connectionProvider;

        /// <inheritdoc />
        public IBankAccountRepository BankAccountRepository { get; }
        /// <inheritdoc />
        public IBankAccountHistoryRepository BankAccountHistoryRepository { get; }
        /// <inheritdoc />
        public IUserRepository UserRepository { get; }

        public RepositoryManager(
            IPostgresConnectionProvider connectionProvider, 
            IBankAccountRepository bankAccountRepository,
            IBankAccountHistoryRepository bankAccountHistoryRepository,
            IUserRepository userRepositor)
        {
            _connectionProvider = connectionProvider;
            BankAccountRepository = bankAccountRepository;
            BankAccountHistoryRepository = bankAccountHistoryRepository;
            UserRepository = userRepositor;
        }

        public RepositoryManager(IPostgresConnectionProvider connectionProvider)
        { 
            _connectionProvider = connectionProvider;
            BankAccountRepository = new BankAccountRepository(connectionProvider);
            BankAccountHistoryRepository = new BankAccountHistoryRepository(connectionProvider);
            UserRepository = new UserRepository(connectionProvider);
        }
    }
}

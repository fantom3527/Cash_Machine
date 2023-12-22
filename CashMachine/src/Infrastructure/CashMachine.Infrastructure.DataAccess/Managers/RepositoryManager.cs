using CashMachine.Application.Abstractions.Reposituries;
using CashMachine.Application.Abstractions.Reposituries.Managers;
using CashMachine.Infrastructure.DataAccess.Repositories;
using Itmo.Dev.Platform.Postgres.Connection;

namespace CashMachine.Infrastructure.DataAccess.Managers
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly IPostgresConnectionProvider _connectionProvider;

        public IBankAccountRepository BankAccountRepository { get; }
        public IUserRepository UserRepository { get; }

        public RepositoryManager(IPostgresConnectionProvider connectionProvider, IBankAccountRepository bankAccountRepository, IUserRepository userRepositor)
        {
            _connectionProvider = connectionProvider;
            BankAccountRepository = bankAccountRepository;
            UserRepository = userRepositor;
        }

        public RepositoryManager(IPostgresConnectionProvider connectionProvider)
        { 
            _connectionProvider = connectionProvider;
            BankAccountRepository = new BankAccountRepository(connectionProvider);
            UserRepository = new UserRepository(connectionProvider);
        }
    }
}

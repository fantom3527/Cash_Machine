using CashMachine.Application.Abstractions.Reposituries;
using CashMachine.Application.Models.BankAccounts;
using Itmo.Dev.Platform.Postgres.Connection;

namespace CashMachine.Infrastructure.DataAccess.Repositories
{
    public class BankAccountRepository : IBankAccountRepository
    {
        private readonly IPostgresConnectionProvider _connectionProvider;
        public BankAccountRepository(IPostgresConnectionProvider connectionProvider)
            => _connectionProvider = connectionProvider;

        public BankAccount GetByNumberAndPinCode(ushort number, string pinCodeHash)
        {
            return null;
        }

        public Guid Create(BankAccount bankAccount)
        {
            return Guid.Empty;
        }

        public decimal GetBalance(Guid id)
        {
            return new decimal();
        }

        public decimal WithdrawMoney(Guid id, decimal amount)
        {
            return new decimal();
        }

        public decimal TopUpMoney(Guid id, decimal amount)
        {
            return new decimal();
        }
    }
}

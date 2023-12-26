using CashMachine.Application.Abstractions.Reposituries.Managers;
using CashMachine.Application.Models.BankAccounts;
using CashMachine.Application.Services.BankAccounts;
using NSubstitute;

namespace CashMachine.Tests.Tests.BankAccounts
{
    public class WithdrawBalanceTests
    {
        [Fact]
        public void WithdrawMoney_EnoughMoneyTests()
        {
            //Arrange
            var repositoryManager = Substitute.For<IRepositoryManager>();
            var bankAccountService = new BankAccountService(repositoryManager);

            var bankAccountId = Guid.NewGuid();
            var initialBalance = 1000;
            var withdrawalAmount = 500;

            bankAccountService.GetBalance(bankAccountId).Returns(initialBalance);

            // Act
            var result = bankAccountService.WithdrawMoney(bankAccountId, withdrawalAmount);

            // Assert
            Assert.Equal(initialBalance - withdrawalAmount, result);
            // убеждаемся, что метод UpdateBalance был вызван с правильными параметрами
            repositoryManager.BankAccountRepository.Received(1).UpdateBalance(bankAccountId, initialBalance - withdrawalAmount);
        }

        [Fact]
        public void WithdrawMoney_NotEnoughMoneyTests()
        {
            // Arrange
            var repositoryManager = Substitute.For<IRepositoryManager>();
            var bankAccountService = new BankAccountService(repositoryManager);

            var accountId = Guid.NewGuid();
            var initialBalance = 100m;
            var withdrawalAmount = 200m;

            bankAccountService.GetBalance(accountId).Returns(initialBalance);

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => bankAccountService.WithdrawMoney(accountId, withdrawalAmount));
            repositoryManager.BankAccountRepository.DidNotReceive().UpdateBalance(Arg.Any<Guid>(), Arg.Any<decimal>());
            repositoryManager.BankAccountHistoryRepository.DidNotReceive().Create(Arg.Any<BankAccountHistory>());
        }
    }
}

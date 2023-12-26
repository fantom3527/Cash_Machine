using CashMachine.Application.Abstractions.Reposituries.Managers;
using CashMachine.Application.Services.BankAccounts;
using NSubstitute;

namespace CashMachine.Tests.Tests.BankAccount
{
    public class TopUpBalanceTests
    {
        [Fact]
        public void TopUpMoneyTests()
        {
            //Arrange
            var repositoryManager = Substitute.For<IRepositoryManager>();
            var bankAccountService = new BankAccountService(repositoryManager);

            var bankAccountId = Guid.NewGuid();
            var initialBalance = 1000;
            var withdrawalAmount = 500;

            bankAccountService.GetBalance(bankAccountId).Returns(initialBalance);

            // Act
            var result = bankAccountService.TopUpMoney(bankAccountId, withdrawalAmount); 

            // Assert
            Assert.Equal(initialBalance + withdrawalAmount, result);
            // убеждаемся, что метод UpdateBalance был вызван с правильными параметрами
            repositoryManager.BankAccountRepository.Received(1).UpdateBalance(bankAccountId, initialBalance + withdrawalAmount); 
        }
    }
}

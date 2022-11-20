using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Domain;
using Moq;
using Xunit;

namespace TestProject.Tests
{
    public class AccountRepositoryTests
    {
        [Fact]
        public void GetAllAccountsAsync_ReturnsListOfAccounts_WithSingleAccount()
        {
            //Arrange
            var mockAccount = new Mock<IAccountRepository>();

            mockAccount.Setup(r => r.GetAllAccountsAsync(false))
                .Returns(Task.FromResult(GetSingleAccount()));

            //Act
            var result = mockAccount.Object.GetAllAccountsAsync(false).GetAwaiter().GetResult().ToList();

            // Assert
            Assert.IsType<List<Account>>(result);
            Assert.Single(result);

        }


        [Fact]
        public void GetAllAccountAsync_ReturnsListOfAccounts_WithNull()
        {
            //Arrange
            var mockAccount = new Mock<IAccountRepository>();

            mockAccount.Setup(repo => (repo.GetAllAccountsAsync(false)))
                .Returns(Task.FromResult(GetEmptyAccountsList()));

            //Act
            var result = mockAccount.Object.GetAllAccountsAsync(false).GetAwaiter().GetResult().ToList();

            //Assert
            Assert.IsType<List<User>>(result);
            Assert.Empty(result);

        }

        private IEnumerable<Account> GetEmptyAccountsList()
        {
            return new List<Account> { };
        }

        private IEnumerable<Account> GetSingleAccount()
        {
            var testAccounts = new List<Account>()
            {
                new Account()
                {
                    UserId = 5,
                    Id = 2
                }
            };

            return testAccounts;
        }
    }
}


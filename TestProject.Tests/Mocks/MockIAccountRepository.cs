using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Domain;
using Moq;

namespace TestProject.Tests.Mocks
{
    internal class MockIAccountRepository
    {
        public static Mock<IAccountRepository> GetMock()
        {
            var mock = new Mock<IAccountRepository>();

            mock.Setup(x => x.GetAllAccountsAsync(false)).Returns(Task.FromResult(GetSingleAccount()));

            return mock;
        }

        private static IEnumerable<Account> GetSingleAccount()
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

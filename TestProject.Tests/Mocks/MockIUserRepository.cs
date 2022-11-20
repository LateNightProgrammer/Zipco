using Contracts;
using Domain;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Tests.Mocks
{
    internal class MockIUserRepository
    {

        public static Mock<IUserRepository> GetMock()
        {
            var mock = new Mock<IUserRepository>();

            mock.Setup(x => x.GetAllUsersAsync(false)).Returns(Task.FromResult(GetAllTestUsers()));

            mock.Setup(x => x.FindUserByEmail(It.IsAny<string>()))
                .Returns((string email) => Task.FromResult(GetAllTestUsers().FirstOrDefault(u => u.Email == email)));

            mock.Setup(x => x.GetUserAsync(It.IsAny<int>(), false))
                .Returns((int id, bool trackable) => Task.FromResult(GetAllTestUsers().FirstOrDefault(u =>u.Id == id)));

            mock.Setup(m => m.CreateUserAsync(It.IsAny<User>()))
                .Callback(() => { return; });

            return mock;
        }

        private IEnumerable<User> GetEmptyUsersList()
        {
            return new List<User> { };
        }


        private static IEnumerable<User> GetAllTestUsers()
        {
            return new List<User>
            {
                new User
                {
                    Id = 1,
                    Email = "test.tester@tester.com",
                    Expenses = 2.0M,
                    Income = 1.0M
                }
            };
        }

        private User GetUserByUserIdSampleData()
        {
            return new User
            {
                Id = 4,
                Email = "test.tester@tester.com",
                Expenses = 2.0M,
                Income = 1.0M
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Domain;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Moq;
using Xunit;

namespace TestProject.Tests
{
    public class UserRepositoryTests
    {
        [Fact]
        public void GetAllUsersAsync_ReturnsListOfUsers_WithASingleUser()
        {
            //Arrange
            var mockRepo = new Mock<IUserRepository>();

            mockRepo.Setup(repo => (repo.GetAllUsersAsync(false)))
                .Returns(Task.FromResult(GetAllUsersTest()));

            //Act
            var result = mockRepo.Object.GetAllUsersAsync(false).GetAwaiter().GetResult().ToList();

            //Assert
            Assert.IsType<List<User>>(result);
            Assert.Single(result);

        }


        [Fact]
        public void GetAllUsersAsync_ReturnsListOfUsers_WithNullUsersList()
        {
            //Arrange
            var mockRepo = new Mock<IUserRepository>();

            mockRepo.Setup(repo => (repo.GetAllUsersAsync(false)))
                .Returns(Task.FromResult(GetEmptyUsersList()));

            //Act
            var result = mockRepo.Object.GetAllUsersAsync(false).GetAwaiter().GetResult().ToList();

            //Assert
            Assert.IsType<List<User>>(result);
            Assert.Empty(result);

        }

        [Fact]
        public void GetAllUsersAsync_ReturnsUserWithUserId()
        {
            //Arrange
            var mockRepo = new Mock<IUserRepository>();

            var testUserId = 4;

            mockRepo.Setup(repo => (repo.GetUserAsync(testUserId,false)))
                .Returns(Task.FromResult(GetUserByUserIdSampleData()));

            //Act
            var result = mockRepo.Object.GetUserAsync(testUserId,false).GetAwaiter().GetResult();

            //Assert
            Assert.IsType<User>(result);
            Assert.Equal(result.Id, testUserId);

        }


        [Fact]
        public void GetAllUsersAsync_ReturnsUserWithUserId_UserIdNotFound()
        {
            //Arrange
            var mockRepo = new Mock<IUserRepository>();

            var testUserId = 5;

            mockRepo.Setup(repo => (repo.GetUserAsync(testUserId, false)))
                .Returns(Task.FromResult((User)null));

            //Act
            var result = mockRepo.Object.GetUserAsync(testUserId, false).GetAwaiter().GetResult();

            //Assert
            Assert.Null(result);

        }

        private IEnumerable<User> GetEmptyUsersList()
        {
            return new List<User>{ };
        }


        private IEnumerable<User> GetAllUsersTest()
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
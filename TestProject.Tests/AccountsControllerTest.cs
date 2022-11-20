using AutoMapper;
using Domain.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TestProject.Tests.Mocks;
using TestProject.WebAPI.Controllers;
using TestProject.WebAPI;
using TestProject.WebAPI.Services;
using Xunit;

namespace TestProject.Tests
{
    public class AccountsControllerTest
    {
        public IMapper GetMapper()
        {
            var mappingProfile = new MappingProfile();

            var configuration = new MapperConfiguration(c => c.AddProfile(mappingProfile));

            return new Mapper(configuration);
        }

        [Fact]
        public async void GetAllAccounts_ReturnAllAccounts()
        {
            //Arrange
            var userRepo = RepoWrapper.GetMock();

            var mapper = GetMapper();

            var logger = new LogManager();

            //Act
            var accountController = new AccountsController(userRepo.Object, logger, mapper);

            var result = await accountController.Accounts() as ObjectResult;


            //Assert
            Assert.NotNull(result);

            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);

            Assert.IsType<List<AccountsDto>>(result.Value);
        }
    }
}

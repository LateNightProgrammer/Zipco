using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Domain.Dtos;
using TestProject.Tests.Mocks;
using TestProject.WebAPI;
using TestProject.WebAPI.Controllers;
using TestProject.WebAPI.Services;
using Xunit;

namespace TestProject.Tests
{
    public class UsersControllerTest
    {
        public IMapper GetMapper()
        {
            var mappingProfile = new MappingProfile();

            var configuration = new MapperConfiguration(c => c.AddProfile(mappingProfile));

            return new Mapper(configuration);
        }

        [Fact]
        public async void GetAllUsers_ReturnAllUsers()
        {
            //Arrange
            var userRepo = RepoWrapper.GetMock();

            var mapper = GetMapper();

            var logger = new LogManager();

            //Act
            var userController = new UsersController(userRepo.Object, logger, mapper);

            var result = await userController.GetAllUsers() as ObjectResult;


            //Assert
            Assert.NotNull(result);

            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);

            Assert.IsType<List<UsersDto>>(result.Value);
        }

        [Fact]
        public async void GetUserById_WhenUserReturns()
        {
            //Arrange
            var userRepo = RepoWrapper.GetMock();

            var mapper = GetMapper();

            var logger = new LogManager();

            //Act
            var userController = new UsersController(userRepo.Object, logger, mapper);

            var result = await userController.Users(1) as ObjectResult;


            //Assert
            Assert.NotNull(result);

            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);

            Assert.IsType<UsersDto>(result.Value);
        }


        [Fact]
        public async void GetUserById_WhenUserNotFound()
        {
            //Arrange
            var userRepo = RepoWrapper.GetMock();

            var mapper = GetMapper();

            var logger = new LogManager();

            //Act
            var userController = new UsersController(userRepo.Object, logger, mapper);

            var result = await userController.Users(6) as ObjectResult;


            //Assert
            Assert.Equal(StatusCodes.Status404NotFound, result.StatusCode);
        }


        [Fact]
        public async void GetUserByUserID_WhenUserIdIsZero_ReturnsBadResponse()
        {
            //Arrange
            var userRepo = RepoWrapper.GetMock();

            var mapper = GetMapper();

            var logger = new LogManager();

            //Act
            var userController = new UsersController(userRepo.Object, logger, mapper);

            var result = await userController.Users(0) as ObjectResult;


            //Assert
            Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
        }
    }
}

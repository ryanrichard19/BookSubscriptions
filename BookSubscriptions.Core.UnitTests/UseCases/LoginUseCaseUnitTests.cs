using System;
using System.Threading.Tasks;
using BookSubscriptions.Core.Domain.Entities;
using BookSubscriptions.Core.Dto;
using BookSubscriptions.Core.Dto.UseCaseRequests;
using BookSubscriptions.Core.Dto.UseCaseResponses;
using BookSubscriptions.Core.Interfaces;
using BookSubscriptions.Core.Interfaces.Gateways.Repositories;
using BookSubscriptions.Core.Interfaces.Services;
using BookSubscriptions.Core.UseCases;
using Moq;
using Xunit;

namespace BookSubscriptions.Core.UnitTests.UseCases
{
    public class LoginUseCaseUnitTests
    {
        [Fact]
        public async void Can_Login()
        {
            // arrange
            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository
                .Setup(repo => repo.FindByEmail(It.IsAny<string>()))
                .Returns(Task.FromResult(new User("", "", "", "")));

            mockUserRepository
                .Setup(repo => repo.CheckPassword(It.IsAny<User>(), It.IsAny<string>()))
                .Returns(Task.FromResult(true));

            var mockJwtFactory = new Mock<IJwtFactory>();
            mockJwtFactory
                .Setup(repo => repo.GenerateEncodedToken(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(Task.FromResult(new Token("", "", 0)));

            var useCase = new LoginUseCase(mockUserRepository.Object, mockJwtFactory.Object);

            var mockOutputPort = new Mock<IOutputPort<LoginResponse>>();
            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<LoginResponse>()));

            // act
            var response = await useCase.Handle(new LoginRequest("email", "password"), mockOutputPort.Object);

            // assert
            Assert.True(response);
        }

        [Fact]
        public async void Cant_Login_When_Missing_Email()
        {
            // arrange
            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository
                .Setup(repo => repo.FindByName(It.IsAny<string>()))
                .Returns(Task.FromResult(new User("", "", "", "")));

            mockUserRepository
                .Setup(repo => repo.CheckPassword(It.IsAny<User>(), It.IsAny<string>()))
                .Returns(Task.FromResult(true));

            var mockJwtFactory = new Mock<IJwtFactory>();
            mockJwtFactory
                .Setup(repo => repo.GenerateEncodedToken(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(Task.FromResult(new Token("", "", 0)));

            var useCase = new LoginUseCase(mockUserRepository.Object, mockJwtFactory.Object);

            var mockOutputPort = new Mock<IOutputPort<LoginResponse>>();
            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<LoginResponse>()));

            // act
            var response = await useCase.Handle(new LoginRequest("", "password"), mockOutputPort.Object);

            // assert
            Assert.False(response);
        }


        [Fact]
        public async void Cant_Login_When_Unknown_Account()
        {
            // arrange
            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository
                .Setup(repo => repo.FindByName(It.IsAny<string>()))
                .Returns(Task.FromResult<User>(null));

            mockUserRepository
                .Setup(repo => repo.CheckPassword(It.IsAny<User>(), It.IsAny<string>()))
                .Returns(Task.FromResult(true));

            var mockJwtFactory = new Mock<IJwtFactory>();
            mockJwtFactory
                .Setup(repo => repo.GenerateEncodedToken(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(Task.FromResult(new Token("", "", 0)));

            var useCase = new LoginUseCase(mockUserRepository.Object, mockJwtFactory.Object);

            var mockOutputPort = new Mock<IOutputPort<LoginResponse>>();
            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<LoginResponse>()));

            // act
            var response = await useCase.Handle(new LoginRequest("", "password"), mockOutputPort.Object);

            // assert
            Assert.False(response);
        }

        [Fact]
        public async void Cant_Login_When_Password_Validation_Fails()
        {
            // arrange
            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository
                .Setup(repo => repo.FindByName(It.IsAny<string>()))
                .Returns(Task.FromResult<User>(null));

            mockUserRepository
                .Setup(repo => repo.CheckPassword(It.IsAny<User>(), It.IsAny<string>()))
                .Returns(Task.FromResult(false));

            var mockJwtFactory = new Mock<IJwtFactory>();
            mockJwtFactory
                .Setup(repo => repo.GenerateEncodedToken(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(Task.FromResult(new Token("", "", 0)));

            var useCase = new LoginUseCase(mockUserRepository.Object, mockJwtFactory.Object);

            var mockOutputPort = new Mock<IOutputPort<LoginResponse>>();
            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<LoginResponse>()));

            // act
            var response = await useCase.Handle(new LoginRequest("", "password"), mockOutputPort.Object);

            // assert
            Assert.False(response);
        }
    }
}

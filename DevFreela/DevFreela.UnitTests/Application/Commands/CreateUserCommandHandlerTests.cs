using DevFreela.Application.Commands.CreateUser;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Core.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DevFreela.UnitTests.Application.Commands
{
    public class CreateUserCommandHandlerTests
    {
        [Fact]
        public async Task InputDataIsOk_Executed_ReturnUserId()
        {
            // Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            var authServiceMock = new Mock<IAuthService>();

            var createUserCommand = new CreateUserCommand()
            {
                FullName = "nameTest",
                Password = "passwordTest",
                BirthDate = DateTime.Now,
                Email = "email@test.com",
                Role = "roleTest"
            };

            var createUserCommandHandler = new CreateUserCommandHandler(userRepositoryMock.Object,authServiceMock.Object);

            // Act
            var id = await createUserCommandHandler.Handle(createUserCommand, new CancellationToken());

            // Assert
            authServiceMock.Verify(ar => ar.ComputeSha256Hash(createUserCommand.Password));
            userRepositoryMock.Verify(ur => ur.AddAsync(It.IsAny<User>()), Times.Once);        
        }
    }
}

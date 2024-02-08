using DevFreela.Application.Queries.GetUser;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;
using Xunit;

namespace DevFreela.UnitTests.Application.Queries
{
    public class GetUserQueryHandlerTests
    {
        [Fact]
        public async Task UserExist_Executed_ReturnUserViewModel()
        {
            // Arrange
            var user = new User("Name test", "Email@test.com", DateTime.Now, "passwordTest", "teste");

            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(ur => ur.GetByidAsync(user.Id).Result).Returns(user);
            var getUserQuery = new GetUserQuery(user.Id);
            var getUserQueryHandler = new GetUserQueryHandler(userRepositoryMock.Object);

            // Act
            var userViewModel = await getUserQueryHandler.Handle(getUserQuery, new CancellationToken());

            // Assert
            Assert.NotNull(userViewModel.FullName);
            Assert.NotEmpty(userViewModel.FullName);
            Assert.NotNull(userViewModel.Email);
            Assert.NotEmpty(userViewModel.Email);
            Assert.Equal(user.FullName, userViewModel.FullName);
            Assert.Equal(user.Email, userViewModel.Email);

            userRepositoryMock.Verify(ur => ur.GetByidAsync(user.Id).Result, Times.Once);
        }
    }
}

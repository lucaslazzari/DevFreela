using DevFreela.Application.Commands.CreateComment;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;
using Xunit;

namespace DevFreela.UnitTests.Application.Commands
{
    public class CreateCommentCommandHandlerTests
    {
        [Fact]
        public async Task InputDataIsOk_Executed_ReturnNoContent()
        {
            // Arrange
            var projectRepositoryMock = new Mock<IProjectRepository>();
            var createCommentCommand = new CreateCommentCommand()
            {
                Content = "ContentTest",
                IdProject = 1,
                IdUser = 2
            };

            var createCommentCommandHandler = new CreateCommentCommandHandler(projectRepositoryMock.Object);

            // Act
            var comment = await createCommentCommandHandler.Handle(createCommentCommand, new CancellationToken());

            // Assert
            
            projectRepositoryMock.Verify(pr => pr.AddCommentAsync(It.IsAny<ProjectComment>()), Times.Once);
        }
    }
}

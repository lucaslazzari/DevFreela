using DevFreela.Application.Commands.DeleteProject;
using DevFreela.Core.Entities;
using DevFreela.Core.Enums;
using DevFreela.Core.Repositories;
using Moq;
using Xunit;

namespace DevFreela.UnitTests.Application.Commands
{
    public class DeleteProjectCommandHandlerTests
    {
        [Fact]
        public async Task InputDataIsOk_Executed_ReturnProjectDelete()
        {
            // Arrange
            Project project = new Project("TitleTest", "DescriptionTest", 1,2, 10000);

            var projectRepositoryMock = new Mock<IProjectRepository>();
            projectRepositoryMock.Setup(pr => pr.GetByIdAsync(project.Id).Result).Returns(project);

            var deleteProjectCommand = new DeleteProjectCommand();          

            var deleteProjectCommandHandler = new DeleteProjectCommandHandler(projectRepositoryMock.Object);
            
            // Act
            var delete = await deleteProjectCommandHandler.Handle(deleteProjectCommand, new CancellationToken());

            // Assert
            Assert.NotNull(project);
            Assert.Equal(project.Id, deleteProjectCommand.Id);
            Assert.Equal(ProjectStatusEnum.Cancelled, project.Status);

            projectRepositoryMock.Verify(pr => pr.GetByIdAsync(project.Id), Times.Once);
            projectRepositoryMock.Verify(pr => pr.SaveChangesAsync(It.IsAny<Project>()), Times.Once);

        }
    }
}

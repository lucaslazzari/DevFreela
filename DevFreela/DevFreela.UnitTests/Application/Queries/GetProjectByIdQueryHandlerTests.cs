using DevFreela.Application.Queries.GetProjectById;
using DevFreela.Core.Repositories;
using Moq;
using Xunit;

namespace DevFreela.UnitTests.Application.Queries
{
    public class GetProjectByIdQueryHandlerTests
    {
        [Fact]
        public async Task ProjectExist_Executed_ReturnProjectDetailsViewModel()
        {
            // Arrange
            var id = 1;

            var projectRepositoryMock = new Mock<IProjectRepository>();
            projectRepositoryMock.Setup(pr => pr.GetByIdAsync(id).Result);
            var getProjectByIdQuery = new GetProjectByIdQuery(id);
            var getProjectByIdQueryHandler = new GetProjectByIdQueryHandler(projectRepositoryMock.Object);

            // Act
            var projectDetailsViewModel = await getProjectByIdQueryHandler.Handle(getProjectByIdQuery, new CancellationToken());

            // Assert
            projectRepositoryMock.Verify(pr => pr.GetByIdAsync(id).Result, Times.Once);

        }
    }
}

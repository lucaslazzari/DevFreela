using DevFreela.Application.Queries.GetProjectById;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DevFreela.UnitTests.Application.Queries
{
    public class GetProjectByIdQueryHandlerTests
    {
        [Fact]
        public async Task ProjectExist_Executed_ReturnProjectDetailsViewModel()
        {
            // Arrange

            var projectRepositoryMock = new Mock<IProjectRepository>();
            var project = new Project("Nome Do Teste 1", "Descricao de Teste 1", 1, 2, 10000);
            int projectId = project.Id;
            projectId = 1;

            
            projectRepositoryMock.Setup(pr => pr.GetByIdAsync(projectId).Result).Returns(project);

            var getProjectByIdQuery = new GetProjectByIdQuery(projectId);
            var getProjectByIdQueryHandler = new GetProjectByIdQueryHandler(projectRepositoryMock.Object);

            // Act
            var projectDetailsViewModel = await getProjectByIdQueryHandler.Handle(getProjectByIdQuery, new CancellationToken());

            // Assert
            Assert.Equal(projectId, projectDetailsViewModel.Id);

            projectRepositoryMock.Verify(pr => pr.GetByIdAsync(projectId).Result, Times.Once);

        }
    }
}

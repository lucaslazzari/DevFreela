using DevFreela.Application.Queries.GetAllSkills;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;
using Xunit;

namespace DevFreela.UnitTests.Application.Queries
{
    public class GetAllSkillsQueryHandlerTests
    {
        [Fact]
        public async Task ThreeSkillsExist_Executed_ReturnThreeSkillsViewModel()
        {
            // Arrange
            var skills = new List<Skill>
            {
                new Skill("skillTest1"),
                new Skill("skillTest2"),
                new Skill("skillTest3")
            };

            var skillRepositoryMock = new Mock<ISkillRepository>();
            skillRepositoryMock.Setup(sr => sr.GetAllAsync().Result).Returns(skills);

            var getAllSkillsQuery = new GetAllSkillsQuery();
            var getAllSkillsQueryHandler = new GetAllSkillsQueryHandler(skillRepositoryMock.Object);

            // Act
            var getSkillsViewModel = await getAllSkillsQueryHandler.Handle(getAllSkillsQuery, new CancellationToken()); 

            // Assert
            Assert.NotNull(getSkillsViewModel);
            Assert.NotEmpty(getSkillsViewModel);
            Assert.Equal(skills.Count, getSkillsViewModel.Count);

            skillRepositoryMock.Verify(sr => sr.GetAllAsync().Result, Times.Once);
        }
    }
}

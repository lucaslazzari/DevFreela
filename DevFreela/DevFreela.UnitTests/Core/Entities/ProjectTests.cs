using DevFreela.Core.Entities;
using DevFreela.Core.Enums;
using Xunit;

namespace DevFreela.UnitTests.Core.Entities
{
    public class ProjectTests
    {
        [Fact]
        public void TestIfProjectStartWorks()
        {
            var project = new Project("name test", "description test", 1, 2, 10000);

            Assert.Equal(ProjectStatusEnum.Created, project.Status);
            Assert.Null(project.StartedAt);

            Assert.NotNull(project.Title);
            Assert.NotEmpty(project.Title);

            Assert.NotNull(project.Description);
            Assert.NotEmpty(project.Description);   

            project.Start();

            Assert.Equal(ProjectStatusEnum.InProgress, project.Status);
            Assert.NotNull(project.StartedAt);
        }

        [Fact]
        public void TestIfProjectCancelWorks()
        {
            var project = new Project("name test", "description test", 1, 2, 10000);
            Assert.Equal(ProjectStatusEnum.Created, project.Status);
            Assert.Null(project.StartedAt);

            Assert.NotNull(project.Title);
            Assert.NotEmpty(project.Title);

            Assert.NotNull(project.Description);
            Assert.NotEmpty(project.Description);

            project.Start();

            Assert.Equal(ProjectStatusEnum.InProgress, project.Status);
            Assert.NotNull(project.StartedAt);

            project.Cancel();

            Assert.Equal(ProjectStatusEnum.Cancelled, project.Status);
        }

        [Fact]
        public void TestIfProjectFinishWorks() 
        {
            var project = new Project("name test", "description test", 1, 2, 10000);
            Assert.Equal(ProjectStatusEnum.Created, project.Status);
            Assert.Null(project.StartedAt);

            Assert.NotNull(project.Title);
            Assert.NotEmpty(project.Title);

            Assert.NotNull(project.Description);
            Assert.NotEmpty(project.Description);

            project.Start();

            Assert.Equal(ProjectStatusEnum.InProgress, project.Status);
            Assert.NotNull(project.StartedAt);

            project.Finish();
            Assert.Equal(ProjectStatusEnum.Finished, project.Status);
            Assert.NotNull(project.FinishedAt);
        }

        [Fact]
        public void TestIfProjectUpdateWorks()
        {
            var project = new Project("name test", "description test", 1, 2, 10000);

            project.Update("test name update", "description test Update", 20000);

            Assert.NotEmpty(project.Title);
            Assert.IsType<string>(project.Title);
            Assert.NotNull(project.Title);
            Assert.NotEmpty(project.Description);
            Assert.NotNull(project.Description);
            Assert.IsType<string>(project.Description);
            Assert.IsType<decimal>(project.TotalCost);
        }
    }
}

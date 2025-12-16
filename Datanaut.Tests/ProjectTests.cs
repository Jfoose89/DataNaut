using Datanaut.Models;
using Datanaut.Tests.Utilities;
using Xunit;

namespace Datanaut.Tests.DbContextTests
{
    public class ProjectTests
    {
        [Fact]
        public void AddProject_ShouldSaveCorrectly()
        {
            using var context = InMemoryContextFactory.CreateContext("AddProjectDB");

            var manager = new ProjectManager { FkroleId = 1 };

            var project = new Project
            {
                ProjectName = "Test Project",
                ProjectStartDate = new DateOnly(2025, 1, 1),
                FkprojectManagerId = manager.PkprojectManagerId
            };

            context.Projects.Add(project);
            context.SaveChanges();

            Assert.Equal(1, context.Projects.Count());
        }

        [Fact]
        public void AddProject_ShouldLinkToProjectManager()
        {
            using var context = InMemoryContextFactory.CreateContext("ProjectManagerRelationDB");

            var manager = new ProjectManager { FkroleId = 1 };
            context.SaveChanges();

            var project = new Project
            {
                ProjectName = "New Build",
                ProjectStartDate = new DateOnly(2025, 2, 1),
                FkprojectManagerId = manager.PkprojectManagerId
            };

            context.Projects.Add(project);
            context.SaveChanges();

            var result = context.Projects
                .Where(p => p.FkprojectManagerId == manager.PkprojectManagerId)
                .FirstOrDefault();

            Assert.NotNull(result);
            Assert.Equal("New Build", result.ProjectName);
        }
    }
}

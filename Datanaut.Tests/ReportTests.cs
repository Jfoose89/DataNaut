using Datanaut.Models;
using Datanaut.Tests.Utilities;
using Xunit;

namespace Datanaut.Tests.DbContextTests
{
    public class ReportTests
    {
        [Fact]
        public void AddReport_ShouldAttachToProject()
        {
            using var context = InMemoryContextFactory.CreateContext("ReportDB");

            var manager = new ProjectManager { FkroleId = 1 };

            var project = new Project
            {
                ProjectName = "Survey",
                ProjectStartDate = new DateOnly(2025, 1, 10),
                FkprojectManagerId = manager.PkprojectManagerId
            };

            context.Projects.Add(project);
            context.SaveChanges();

            var report = new Report
            {
                FkprojectId = project.PkprojectId,
                ReportStartDate = DateOnly.FromDateTime(DateTime.Now),
                ReportEndDate = DateOnly.FromDateTime(DateTime.Now.AddDays(7))
            };

            context.Reports.Add(report);
            context.SaveChanges();

            Assert.Single(context.Reports);
        }
    }
}

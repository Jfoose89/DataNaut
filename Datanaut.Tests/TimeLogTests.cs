using Datanaut.Models;
using Datanaut.Tests.Utilities;
using Xunit;

namespace Datanaut.Tests.DbContextTests
{
    public class TimeLogTests
    {
        [Fact]
        public void AddTimeLog_ShouldSaveCorrectly()
        {
            using var context = InMemoryContextFactory.CreateContext("TimeLogDB");

            var role = new Role { RoleName = "Tester" };
            var manager = new ProjectManager { FkroleId = 1 };
            var project = new Project
            {
                ProjectName = "QA",
                ProjectStartDate = new DateOnly(2025, 4, 1),
                FkprojectManagerId = manager.PkprojectManagerId
            };

            context.Roles.Add(role);
            context.ProjectManagers.Add(manager);
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

            var member = new TeamMember
            {
                Name = "Alex",
                FkprojectId = project.PkprojectId,
                FkroleId = role.PkroleId,
                FkprojectManagerId = manager.PkprojectManagerId
            };

            context.TeamMembers.Add(member);
            context.SaveChanges();

            var timeLog = new TimeLog
            {
                FkreportId = report.PkreportId,
                FkteamMemberId = member.PkteamMemberId,
                TimeWorked = 5m,
                DateLogged = DateOnly.FromDateTime(DateTime.Now)
            };

            context.TimeLogs.Add(timeLog);
            context.SaveChanges();

            Assert.Single(context.TimeLogs);
        }
    }
}

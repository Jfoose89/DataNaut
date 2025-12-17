using Datanaut.Models;
using Datanaut.Tests.Utilities;
using Xunit;

namespace Datanaut.Tests.DbContextTests
{
    public class TeamMemberTests
    {
        [Fact]
        public void AddTeamMember_ShouldSetProjectRoleAndManager()
        {
            using var context = InMemoryContextFactory.CreateContext("TeamMemberDB");

            var role = new Role { RoleName = "Developer" };
            var manager = new ProjectManager { FkroleId = 1 };
            var project = new Project
            {
                ProjectName = "Migration",
                ProjectStartDate = new DateOnly(2025, 3, 1),
                FkprojectManagerId = manager.PkprojectManagerId
            };

            context.Roles.Add(role);
            context.ProjectManagers.Add(manager);
            context.Projects.Add(project);
            context.SaveChanges();

            var member = new TeamMember
            {
                Name = "Tom",
                FkroleId = role.PkroleId,
                FkprojectId = project.PkprojectId,
                FkprojectManagerId = manager.PkprojectManagerId
            };

            context.TeamMembers.Add(member);
            context.SaveChanges();

            Assert.Equal(1, context.TeamMembers.Count());
        }
    }
}

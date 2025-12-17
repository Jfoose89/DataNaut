using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Datanaut.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    PKRoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Role__B962131494311597", x => x.PKRoleID);
                });

            migrationBuilder.CreateTable(
                name: "ProjectManager",
                columns: table => new
                {
                    PKProjectManagerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FKRoleID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ProjectM__AE6D6ACEB67AB191", x => x.PKProjectManagerID);
                    table.ForeignKey(
                        name: "FK_ProjectManager_Role",
                        column: x => x.FKRoleID,
                        principalTable: "Role",
                        principalColumn: "PKRoleID");
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    PKProjectID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    ProjectStartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ProjectEndDate = table.Column<DateOnly>(type: "date", nullable: true),
                    Budget = table.Column<decimal>(type: "decimal(12,2)", nullable: true),
                    Status = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    FKProjectManagerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Project__1A1F05A2F3261658", x => x.PKProjectID);
                    table.ForeignKey(
                        name: "FK_Project_ProjectManager",
                        column: x => x.FKProjectManagerID,
                        principalTable: "ProjectManager",
                        principalColumn: "PKProjectManagerID");
                });

            migrationBuilder.CreateTable(
                name: "Report",
                columns: table => new
                {
                    PKReportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FKProjectId = table.Column<int>(type: "int", nullable: false),
                    ReportStartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ReportEndDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Report__BFF8F6AE38A425C4", x => x.PKReportId);
                    table.ForeignKey(
                        name: "FK_Report_Project",
                        column: x => x.FKProjectId,
                        principalTable: "Project",
                        principalColumn: "PKProjectID");
                });

            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    PKResourceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FKProjectID = table.Column<int>(type: "int", nullable: false),
                    ResourceName = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    ResourceType = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Resource__8EF7FE5F3904FD64", x => x.PKResourceID);
                    table.ForeignKey(
                        name: "FK_Resources_Project",
                        column: x => x.FKProjectID,
                        principalTable: "Project",
                        principalColumn: "PKProjectID");
                });

            migrationBuilder.CreateTable(
                name: "TeamMember",
                columns: table => new
                {
                    PKTeamMemberID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    Skill = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    FKProjectID = table.Column<int>(type: "int", nullable: false),
                    FKProjectManagerID = table.Column<int>(type: "int", nullable: false),
                    FKRoleID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TeamMemb__295C6A18A67427BD", x => x.PKTeamMemberID);
                    table.ForeignKey(
                        name: "FK_TeamMember_Project",
                        column: x => x.FKProjectID,
                        principalTable: "Project",
                        principalColumn: "PKProjectID");
                    table.ForeignKey(
                        name: "FK_TeamMember_ProjectManager",
                        column: x => x.FKProjectManagerID,
                        principalTable: "ProjectManager",
                        principalColumn: "PKProjectManagerID");
                    table.ForeignKey(
                        name: "FK_TeamMember_Role",
                        column: x => x.FKRoleID,
                        principalTable: "Role",
                        principalColumn: "PKRoleID");
                });

            migrationBuilder.CreateTable(
                name: "TimeLog",
                columns: table => new
                {
                    PKTimeLogID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FKTeamMemberID = table.Column<int>(type: "int", nullable: false),
                    FKReportID = table.Column<int>(type: "int", nullable: false),
                    Activity = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    TimeWorked = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    DateLogged = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TimeLog__F1CF3406FBCF09AB", x => x.PKTimeLogID);
                    table.ForeignKey(
                        name: "FK_TimeLog_Report",
                        column: x => x.FKReportID,
                        principalTable: "Report",
                        principalColumn: "PKReportId");
                    table.ForeignKey(
                        name: "FK_TimeLog_TeamMember",
                        column: x => x.FKTeamMemberID,
                        principalTable: "TeamMember",
                        principalColumn: "PKTeamMemberID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Project_FKProjectManagerID",
                table: "Project",
                column: "FKProjectManagerID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectManager_FKRoleID",
                table: "ProjectManager",
                column: "FKRoleID");

            migrationBuilder.CreateIndex(
                name: "UQ_Report_Project_DateRange",
                table: "Report",
                columns: new[] { "FKProjectId", "ReportStartDate", "ReportEndDate" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Resources_FKProjectID",
                table: "Resources",
                column: "FKProjectID");

            migrationBuilder.CreateIndex(
                name: "UQ_Resources_Name_Project",
                table: "Resources",
                columns: new[] { "ResourceName", "FKProjectID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_Role_RoleName",
                table: "Role",
                column: "RoleName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeamMember_FKProjectID",
                table: "TeamMember",
                column: "FKProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMember_FKProjectManagerID",
                table: "TeamMember",
                column: "FKProjectManagerID");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMember_FKRoleID",
                table: "TeamMember",
                column: "FKRoleID");

            migrationBuilder.CreateIndex(
                name: "IX_TimeLog_FKReportID",
                table: "TimeLog",
                column: "FKReportID");

            migrationBuilder.CreateIndex(
                name: "IX_TimeLog_FKTeamMemberID",
                table: "TimeLog",
                column: "FKTeamMemberID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Resources");

            migrationBuilder.DropTable(
                name: "TimeLog");

            migrationBuilder.DropTable(
                name: "Report");

            migrationBuilder.DropTable(
                name: "TeamMember");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "ProjectManager");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}

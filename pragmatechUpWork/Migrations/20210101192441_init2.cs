using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace pragmatechUpWork.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    Category = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    MinCost = table.Column<int>(type: "int", nullable: false),
                    MaxCost = table.Column<int>(type: "int", nullable: false),
                    ProjectManager = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GithubUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectInfo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    Cost = table.Column<int>(type: "int", nullable: false),
                    RequiredDays = table.Column<int>(type: "int", nullable: false),
                    PublishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GithubUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaskInfo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Task_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Task_ProjectId",
                table: "Task",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Task");

            migrationBuilder.DropTable(
                name: "Project");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace pragmatechUpWork.Migrations
{
    public partial class test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Task",
                newName: "TaskId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Project",
                newName: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TaskId",
                table: "Task",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ProjectId",
                table: "Project",
                newName: "Id");
        }
    }
}

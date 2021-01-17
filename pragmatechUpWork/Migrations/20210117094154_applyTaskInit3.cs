using Microsoft.EntityFrameworkCore.Migrations;

namespace pragmatechUpWork_CoreMVC.UI.Migrations
{
    public partial class applyTaskInit3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplyTask_Project_ProjectId",
                table: "ApplyTask");

            migrationBuilder.DropIndex(
                name: "IX_ApplyTask_ProjectId",
                table: "ApplyTask");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "ApplyTask");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "ApplyTask",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApplyTask_ProjectId",
                table: "ApplyTask",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplyTask_Project_ProjectId",
                table: "ApplyTask",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

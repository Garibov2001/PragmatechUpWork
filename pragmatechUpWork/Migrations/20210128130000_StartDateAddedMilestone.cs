using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace pragmatechUpWork_CoreMVC.UI.Migrations
{
    public partial class StartDateAddedMilestone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "TaskMilestone",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "TaskMilestone");
        }
    }
}

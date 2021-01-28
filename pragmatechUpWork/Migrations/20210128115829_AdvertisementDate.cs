using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace pragmatechUpWork_CoreMVC.UI.Migrations
{
    public partial class AdvertisementDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Advertisement_EndDate",
                table: "Project",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Advertisement_StartDate",
                table: "Project",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Advertisement_EndDate",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "Advertisement_StartDate",
                table: "Project");
        }
    }
}

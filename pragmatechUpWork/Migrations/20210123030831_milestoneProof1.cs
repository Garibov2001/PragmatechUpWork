using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace pragmatechUpWork_CoreMVC.UI.Migrations
{
    public partial class milestoneProof1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "TaskMilestoneProof",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProofContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProofImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MilestoneId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskMilestoneProof", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TaskMilestoneProof_TaskMilestone_MilestoneId",
                        column: x => x.MilestoneId,
                        principalTable: "TaskMilestone",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaskMilestoneProof_MilestoneId",
                table: "TaskMilestoneProof",
                column: "MilestoneId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskMilestoneProof");

            migrationBuilder.AddColumn<DateTime>(
                name: "PublishDate",
                table: "TaskMilestone",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}

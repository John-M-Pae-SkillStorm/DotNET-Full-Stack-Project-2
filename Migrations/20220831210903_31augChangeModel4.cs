using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TigerPhoneAPI.Migrations
{
    public partial class _31augChangeModel4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Devices_Plans_PlanId",
                table: "Devices");

            migrationBuilder.DropIndex(
                name: "IX_Devices_PlanId",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "PlanId",
                table: "Devices");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlanId",
                table: "Devices",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Devices_PlanId",
                table: "Devices",
                column: "PlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_Plans_PlanId",
                table: "Devices",
                column: "PlanId",
                principalTable: "Plans",
                principalColumn: "PlanId");
        }
    }
}

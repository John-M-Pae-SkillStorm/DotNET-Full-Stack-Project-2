using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TigerPhoneAPI.Migrations
{
    public partial class _31augChangeModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Model",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Devices");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "Devices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Devices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

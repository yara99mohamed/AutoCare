using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoCare.Migrations
{
    public partial class addDataBaseNEW1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_roleId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_roleId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "roleId",
                table: "Users");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RolerId",
                table: "Users",
                column: "RolerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RolerId",
                table: "Users",
                column: "RolerId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RolerId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_RolerId",
                table: "Users");

            migrationBuilder.AddColumn<long>(
                name: "roleId",
                table: "Users",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_roleId",
                table: "Users",
                column: "roleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_roleId",
                table: "Users",
                column: "roleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

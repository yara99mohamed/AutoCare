using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoCare.Migrations
{
    public partial class insitialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckUpsSpareParts_SpareParts_CarSparePartsId",
                table: "CheckUpsSpareParts");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RolesId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "RolesId",
                table: "Users",
                newName: "roleId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_RolesId",
                table: "Users",
                newName: "IX_Users_roleId");

            migrationBuilder.RenameColumn(
                name: "CarSparePartsId",
                table: "CheckUpsSpareParts",
                newName: "CarSparePartId");

            migrationBuilder.RenameIndex(
                name: "IX_CheckUpsSpareParts_CarSparePartsId",
                table: "CheckUpsSpareParts",
                newName: "IX_CheckUpsSpareParts_CarSparePartId");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckUpsSpareParts_SpareParts_CarSparePartId",
                table: "CheckUpsSpareParts",
                column: "CarSparePartId",
                principalTable: "SpareParts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_roleId",
                table: "Users",
                column: "roleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckUpsSpareParts_SpareParts_CarSparePartId",
                table: "CheckUpsSpareParts");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_roleId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "roleId",
                table: "Users",
                newName: "RolesId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_roleId",
                table: "Users",
                newName: "IX_Users_RolesId");

            migrationBuilder.RenameColumn(
                name: "CarSparePartId",
                table: "CheckUpsSpareParts",
                newName: "CarSparePartsId");

            migrationBuilder.RenameIndex(
                name: "IX_CheckUpsSpareParts_CarSparePartId",
                table: "CheckUpsSpareParts",
                newName: "IX_CheckUpsSpareParts_CarSparePartsId");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckUpsSpareParts_SpareParts_CarSparePartsId",
                table: "CheckUpsSpareParts",
                column: "CarSparePartsId",
                principalTable: "SpareParts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RolesId",
                table: "Users",
                column: "RolesId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

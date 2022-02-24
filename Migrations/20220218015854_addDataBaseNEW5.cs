using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoCare.Migrations
{
    public partial class addDataBaseNEW5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckUps_Cars_CarId",
                table: "CheckUps");

            migrationBuilder.DropForeignKey(
                name: "FK_CheckUpsServices_CheckUps_CheckUpsId",
                table: "CheckUpsServices");

            migrationBuilder.DropForeignKey(
                name: "FK_CheckUpsServices_Services_ServicesId",
                table: "CheckUpsServices");

            migrationBuilder.DropForeignKey(
                name: "FK_CheckUpsSpareParts_CheckUps_CheckUpsId",
                table: "CheckUpsSpareParts");

            migrationBuilder.DropForeignKey(
                name: "FK_CheckUpsSpareParts_SpareParts_CarSparePartId",
                table: "CheckUpsSpareParts");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAddress_Users_UserId",
                table: "UserAddress");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RolerId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_CheckUpsSpareParts_CarSparePartId",
                table: "CheckUpsSpareParts");

            migrationBuilder.DropColumn(
                name: "CarSparePartId",
                table: "CheckUpsSpareParts");

            migrationBuilder.AlterColumn<long>(
                name: "RolerId",
                table: "Users",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "NationalIdNumber",
                table: "Users",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 14);

            migrationBuilder.AlterColumn<long>(
                name: "Mobile",
                table: "Users",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 11);

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "UserAddress",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SparePartsId",
                table: "CheckUpsSpareParts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CheckUpsId",
                table: "CheckUpsSpareParts",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ServicesId",
                table: "CheckUpsServices",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CheckUpsId",
                table: "CheckUpsServices",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "CheckUps",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreateBy",
                table: "CheckUps",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CarId",
                table: "CheckUps",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CarLetter",
                table: "Cars",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(12)");

            migrationBuilder.CreateIndex(
                name: "IX_CheckUpsSpareParts_SparePartsId",
                table: "CheckUpsSpareParts",
                column: "SparePartsId");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckUps_Cars_CarId",
                table: "CheckUps",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CheckUpsServices_CheckUps_CheckUpsId",
                table: "CheckUpsServices",
                column: "CheckUpsId",
                principalTable: "CheckUps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CheckUpsServices_Services_ServicesId",
                table: "CheckUpsServices",
                column: "ServicesId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CheckUpsSpareParts_CheckUps_CheckUpsId",
                table: "CheckUpsSpareParts",
                column: "CheckUpsId",
                principalTable: "CheckUps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CheckUpsSpareParts_SpareParts_SparePartsId",
                table: "CheckUpsSpareParts",
                column: "SparePartsId",
                principalTable: "SpareParts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAddress_Users_UserId",
                table: "UserAddress",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RolerId",
                table: "Users",
                column: "RolerId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckUps_Cars_CarId",
                table: "CheckUps");

            migrationBuilder.DropForeignKey(
                name: "FK_CheckUpsServices_CheckUps_CheckUpsId",
                table: "CheckUpsServices");

            migrationBuilder.DropForeignKey(
                name: "FK_CheckUpsServices_Services_ServicesId",
                table: "CheckUpsServices");

            migrationBuilder.DropForeignKey(
                name: "FK_CheckUpsSpareParts_CheckUps_CheckUpsId",
                table: "CheckUpsSpareParts");

            migrationBuilder.DropForeignKey(
                name: "FK_CheckUpsSpareParts_SpareParts_SparePartsId",
                table: "CheckUpsSpareParts");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAddress_Users_UserId",
                table: "UserAddress");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RolerId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_CheckUpsSpareParts_SparePartsId",
                table: "CheckUpsSpareParts");

            migrationBuilder.AlterColumn<long>(
                name: "RolerId",
                table: "Users",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "NationalIdNumber",
                table: "Users",
                type: "int",
                maxLength: 14,
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "Mobile",
                table: "Users",
                type: "int",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "UserAddress",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "SparePartsId",
                table: "CheckUpsSpareParts",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "CheckUpsId",
                table: "CheckUpsSpareParts",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<int>(
                name: "CarSparePartId",
                table: "CheckUpsSpareParts",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ServicesId",
                table: "CheckUpsServices",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "CheckUpsId",
                table: "CheckUpsServices",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "ModifiedBy",
                table: "CheckUps",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CreateBy",
                table: "CheckUps",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CarId",
                table: "CheckUps",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "CarLetter",
                table: "Cars",
                type: "nvarchar(12)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(3)",
                oldMaxLength: 3);

            migrationBuilder.CreateIndex(
                name: "IX_CheckUpsSpareParts_CarSparePartId",
                table: "CheckUpsSpareParts",
                column: "CarSparePartId");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckUps_Cars_CarId",
                table: "CheckUps",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CheckUpsServices_CheckUps_CheckUpsId",
                table: "CheckUpsServices",
                column: "CheckUpsId",
                principalTable: "CheckUps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CheckUpsServices_Services_ServicesId",
                table: "CheckUpsServices",
                column: "ServicesId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CheckUpsSpareParts_CheckUps_CheckUpsId",
                table: "CheckUpsSpareParts",
                column: "CheckUpsId",
                principalTable: "CheckUps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CheckUpsSpareParts_SpareParts_CarSparePartId",
                table: "CheckUpsSpareParts",
                column: "CarSparePartId",
                principalTable: "SpareParts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAddress_Users_UserId",
                table: "UserAddress",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RolerId",
                table: "Users",
                column: "RolerId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

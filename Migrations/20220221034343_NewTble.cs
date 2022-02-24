using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoCare.Migrations
{
    public partial class NewTble : Migration
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
                name: "FK_CheckUpsSpareParts_SpareParts_SparePartsId",
                table: "CheckUpsSpareParts");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAddress_Users_UserId",
                table: "UserAddress");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RolerId",
                table: "Users");

            migrationBuilder.AlterColumn<long>(
                name: "RolerId",
                table: "Users",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "UserAddress",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "SparePartsId",
                table: "CheckUpsSpareParts",
                type: "int",
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
                name: "CarId",
                table: "CheckUps",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateTable(
                name: "CarViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CarNumber = table.Column<int>(type: "int", nullable: false),
                    CarLetter = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    CarModel = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                });

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
                name: "FK_CheckUpsSpareParts_SpareParts_SparePartsId",
                table: "CheckUpsSpareParts",
                column: "SparePartsId",
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

            migrationBuilder.DropTable(
                name: "CarViewModel");

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
                oldClrType: typeof(int),
                oldType: "int",
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

            migrationBuilder.AlterColumn<long>(
                name: "CarId",
                table: "CheckUps",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

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
    }
}

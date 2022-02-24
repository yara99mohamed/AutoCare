using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoCare.Migrations
{
    public partial class m1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckUpsSpareParts_SpareParts_CarSparePartId",
                table: "CheckUpsSpareParts");

            migrationBuilder.DropIndex(
                name: "IX_CheckUpsSpareParts_CarSparePartId",
                table: "CheckUpsSpareParts");

            migrationBuilder.DropColumn(
                name: "SparePartsId",
                table: "CheckUpsSpareParts");

            migrationBuilder.AlterColumn<long>(
                name: "CarSparePartId",
                table: "CheckUpsSpareParts",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CarSparePartId1",
                table: "CheckUpsSpareParts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CheckUpsSpareParts_CarSparePartId1",
                table: "CheckUpsSpareParts",
                column: "CarSparePartId1");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckUpsSpareParts_SpareParts_CarSparePartId1",
                table: "CheckUpsSpareParts",
                column: "CarSparePartId1",
                principalTable: "SpareParts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckUpsSpareParts_SpareParts_CarSparePartId1",
                table: "CheckUpsSpareParts");

            migrationBuilder.DropIndex(
                name: "IX_CheckUpsSpareParts_CarSparePartId1",
                table: "CheckUpsSpareParts");

            migrationBuilder.DropColumn(
                name: "CarSparePartId1",
                table: "CheckUpsSpareParts");

            migrationBuilder.AlterColumn<int>(
                name: "CarSparePartId",
                table: "CheckUpsSpareParts",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SparePartsId",
                table: "CheckUpsSpareParts",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CheckUpsSpareParts_CarSparePartId",
                table: "CheckUpsSpareParts",
                column: "CarSparePartId");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckUpsSpareParts_SpareParts_CarSparePartId",
                table: "CheckUpsSpareParts",
                column: "CarSparePartId",
                principalTable: "SpareParts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

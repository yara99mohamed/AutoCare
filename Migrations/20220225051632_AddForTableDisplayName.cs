using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoCare.Migrations
{
    public partial class AddForTableDisplayName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CheckUpsViewModel",
                columns: table => new
                {
                    Counter = table.Column<int>(type: "int", nullable: false),
                    ArriveDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeaveDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPoints = table.Column<int>(type: "int", nullable: false),
                    CarId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CheckUpsViewModel");
        }
    }
}

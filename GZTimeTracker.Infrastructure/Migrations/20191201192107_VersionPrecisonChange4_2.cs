using Microsoft.EntityFrameworkCore.Migrations;

namespace GZIT.GZTimeTracker.Infrastructure.Migrations
{
    public partial class VersionPrecisonChange4_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Version",
                table: "SystemInformation",
                type: "decimal(4, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(2, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Version",
                table: "Language",
                type: "decimal(4, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(2, 2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Version",
                table: "SystemInformation",
                type: "decimal(2, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(4, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Version",
                table: "Language",
                type: "decimal(2, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(4, 2)");
        }
    }
}

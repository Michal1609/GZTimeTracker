using Microsoft.EntityFrameworkCore.Migrations;

namespace GZIT.GZTimeTracker.Infrastructure.Migrations
{
    public partial class Languaga_and_SytstemInformation_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Version",
                table: "Language",
                type: "decimal(2, 2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "SystemInformation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Version = table.Column<decimal>(type: "decimal(2, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemInformation", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SystemInformation");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "Language");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace GZIT.GZTimeTracker.Infrastructure.Migrations
{
    public partial class AddedLocaleStringResources : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LocaleStringResource",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Language = table.Column<string>(maxLength: 5, nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocaleStringResource", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LocaleStringResource_Language_Name",
                table: "LocaleStringResource",
                columns: new[] { "Language", "Name" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocaleStringResource");
        }
    }
}

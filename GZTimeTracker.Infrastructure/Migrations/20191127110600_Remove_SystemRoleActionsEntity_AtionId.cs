using Microsoft.EntityFrameworkCore.Migrations;

namespace GZIT.GZTimeTracker.Infrastructure.Migrations
{
    public partial class Remove_SystemRoleActionsEntity_AtionId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AtionId",
                table: "SystemRoleActions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AtionId",
                table: "SystemRoleActions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

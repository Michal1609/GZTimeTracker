using Microsoft.EntityFrameworkCore.Migrations;

namespace GZIT.GZTimeTracker.Infrastructure.Migrations
{
    public partial class AddedRolesFunctionality : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Action_Role_RoleEntityId",
                table: "Action");

            migrationBuilder.DropForeignKey(
                name: "FK_Role_User_UserEntityId",
                table: "Role");

            migrationBuilder.DropIndex(
                name: "IX_Role_UserEntityId",
                table: "Role");

            migrationBuilder.DropIndex(
                name: "IX_Action_RoleEntityId",
                table: "Action");

            migrationBuilder.DropColumn(
                name: "UserEntityId",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "RoleEntityId",
                table: "Action");

            migrationBuilder.AddColumn<bool>(
                name: "IsProjecOwner",
                table: "UsersOnProjects",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "UsersOnProjects",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "RoleActions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(nullable: false),
                    Action = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleActions_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "UserProjectRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    ProjectId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProjectRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProjectRoles_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_UserProjectRoles_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_UserProjectRoles_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsersOnProjects_RoleId",
                table: "UsersOnProjects",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleActions_RoleId",
                table: "RoleActions",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProjectRoles_ProjectId",
                table: "UserProjectRoles",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProjectRoles_RoleId",
                table: "UserProjectRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProjectRoles_UserId",
                table: "UserProjectRoles",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersOnProjects_Role_RoleId",
                table: "UsersOnProjects",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersOnProjects_Role_RoleId",
                table: "UsersOnProjects");

            migrationBuilder.DropTable(
                name: "RoleActions");

            migrationBuilder.DropTable(
                name: "UserProjectRoles");

            migrationBuilder.DropIndex(
                name: "IX_UsersOnProjects_RoleId",
                table: "UsersOnProjects");

            migrationBuilder.DropColumn(
                name: "IsProjecOwner",
                table: "UsersOnProjects");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "UsersOnProjects");

            migrationBuilder.AddColumn<int>(
                name: "UserEntityId",
                table: "Role",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoleEntityId",
                table: "Action",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Role_UserEntityId",
                table: "Role",
                column: "UserEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Action_RoleEntityId",
                table: "Action",
                column: "RoleEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Action_Role_RoleEntityId",
                table: "Action",
                column: "RoleEntityId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Role_User_UserEntityId",
                table: "Role",
                column: "UserEntityId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

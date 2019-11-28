using Microsoft.EntityFrameworkCore.Migrations;

namespace GZIT.GZTimeTracker.Infrastructure.Migrations
{
    public partial class RemoveRoleLogic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleActions_Role_RoleId",
                table: "RoleActions");

            migrationBuilder.DropTable(
                name: "UserProjectRoles");

            migrationBuilder.DropTable(
                name: "UsersOnProjects");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropIndex(
                name: "IX_RoleActions_RoleId",
                table: "RoleActions");

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "RoleActions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "RoleActions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProjectId1",
                table: "Action",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProjectIdId",
                table: "Action",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Action_ProjectId1",
                table: "Action",
                column: "ProjectId1");

            migrationBuilder.CreateIndex(
                name: "IX_Action_ProjectIdId",
                table: "Action",
                column: "ProjectIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Action_Project_ProjectId1",
                table: "Action",
                column: "ProjectId1",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Action_Project_ProjectIdId",
                table: "Action",
                column: "ProjectIdId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Action_Project_ProjectId1",
                table: "Action");

            migrationBuilder.DropForeignKey(
                name: "FK_Action_Project_ProjectIdId",
                table: "Action");

            migrationBuilder.DropIndex(
                name: "IX_Action_ProjectId1",
                table: "Action");

            migrationBuilder.DropIndex(
                name: "IX_Action_ProjectIdId",
                table: "Action");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "RoleActions");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "RoleActions");

            migrationBuilder.DropColumn(
                name: "ProjectId1",
                table: "Action");

            migrationBuilder.DropColumn(
                name: "ProjectIdId",
                table: "Action");

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserProjectRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProjectRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProjectRoles_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserProjectRoles_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserProjectRoles_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersOnProjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsProjecOwner = table.Column<bool>(type: "bit", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersOnProjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersOnProjects_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UsersOnProjects_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersOnProjects_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_UsersOnProjects_RoleId",
                table: "UsersOnProjects",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersOnProjects_UserId",
                table: "UsersOnProjects",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersOnProjects_ProjectId_UserId",
                table: "UsersOnProjects",
                columns: new[] { "ProjectId", "UserId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleActions_Role_RoleId",
                table: "RoleActions",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace GZIT.GZTimeTracker.Infrastructure.Migrations
{
    public partial class RolesFunctionality : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Action_Project_ProjectId1",
                table: "Action");

            migrationBuilder.DropForeignKey(
                name: "FK_Action_Project_ProjectIdId",
                table: "Action");

            migrationBuilder.DropTable(
                name: "RoleActions");

            migrationBuilder.DropIndex(
                name: "IX_Action_ProjectId1",
                table: "Action");

            migrationBuilder.DropIndex(
                name: "IX_Action_ProjectIdId",
                table: "Action");

            migrationBuilder.DropColumn(
                name: "Entity",
                table: "Action");

            migrationBuilder.DropColumn(
                name: "Privilegia",
                table: "Action");

            migrationBuilder.DropColumn(
                name: "ProjectId1",
                table: "Action");

            migrationBuilder.DropColumn(
                name: "ProjectIdId",
                table: "Action");

            migrationBuilder.AddColumn<string>(
                name: "Action",
                table: "Action",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "CustomerRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerRoles_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SystemRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    Description = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserInRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    IsSystemRole = table.Column<bool>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserInRoles_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserInRoles_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CustomerRoleActions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerRoleId = table.Column<int>(nullable: false),
                    ActionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerRoleActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerRoleActions_Action_ActionId",
                        column: x => x.ActionId,
                        principalTable: "Action",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerRoleActions_CustomerRoles_CustomerRoleId",
                        column: x => x.CustomerRoleId,
                        principalTable: "CustomerRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SystemRoleActions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SystemRoleId = table.Column<int>(nullable: false),
                    AtionId = table.Column<int>(nullable: false),
                    ActionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemRoleActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SystemRoleActions_Action_ActionId",
                        column: x => x.ActionId,
                        principalTable: "Action",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SystemRoleActions_SystemRoles_SystemRoleId",
                        column: x => x.SystemRoleId,
                        principalTable: "SystemRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerRoleActions_ActionId",
                table: "CustomerRoleActions",
                column: "ActionId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerRoleActions_CustomerRoleId",
                table: "CustomerRoleActions",
                column: "CustomerRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerRoles_UserId",
                table: "CustomerRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemRoleActions_ActionId",
                table: "SystemRoleActions",
                column: "ActionId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemRoleActions_SystemRoleId",
                table: "SystemRoleActions",
                column: "SystemRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInRoles_ProjectId",
                table: "UserInRoles",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInRoles_UserId",
                table: "UserInRoles",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerRoleActions");

            migrationBuilder.DropTable(
                name: "SystemRoleActions");

            migrationBuilder.DropTable(
                name: "UserInRoles");

            migrationBuilder.DropTable(
                name: "CustomerRoles");

            migrationBuilder.DropTable(
                name: "SystemRoles");

            migrationBuilder.DropColumn(
                name: "Action",
                table: "Action");

            migrationBuilder.AddColumn<string>(
                name: "Entity",
                table: "Action",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Privilegia",
                table: "Action",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProjectId1",
                table: "Action",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProjectIdId",
                table: "Action",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RoleActions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleActions", x => x.Id);
                });

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
    }
}

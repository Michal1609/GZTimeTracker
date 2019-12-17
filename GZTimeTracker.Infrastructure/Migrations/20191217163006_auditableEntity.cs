using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GZIT.GZTimeTracker.Infrastructure.Migrations
{
    public partial class auditableEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "UserInRoles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedUTC",
                table: "UserInRoles",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "LastModifiedBy",
                table: "UserInRoles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedUTC",
                table: "UserInRoles",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "User",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedUTC",
                table: "User",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "LastModifiedBy",
                table: "User",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedUTC",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Team",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedUTC",
                table: "Team",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "LastModifiedBy",
                table: "Team",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedUTC",
                table: "Team",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Task",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedUTC",
                table: "Task",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "LastModifiedBy",
                table: "Task",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedUTC",
                table: "Task",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "SystemRoles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedUTC",
                table: "SystemRoles",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "LastModifiedBy",
                table: "SystemRoles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedUTC",
                table: "SystemRoles",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "SystemRoleActions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedUTC",
                table: "SystemRoleActions",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "LastModifiedBy",
                table: "SystemRoleActions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedUTC",
                table: "SystemRoleActions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "SystemInformation",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedUTC",
                table: "SystemInformation",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "LastModifiedBy",
                table: "SystemInformation",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedUTC",
                table: "SystemInformation",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "SpendTimes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedUTC",
                table: "SpendTimes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "LastModifiedBy",
                table: "SpendTimes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedUTC",
                table: "SpendTimes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "RunningTasks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedUTC",
                table: "RunningTasks",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "LastModifiedBy",
                table: "RunningTasks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedUTC",
                table: "RunningTasks",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Project",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedUTC",
                table: "Project",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "LastModifiedBy",
                table: "Project",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedUTC",
                table: "Project",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "LocaleStringResource",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedUTC",
                table: "LocaleStringResource",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "LastModifiedBy",
                table: "LocaleStringResource",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedUTC",
                table: "LocaleStringResource",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Language",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedUTC",
                table: "Language",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "LastModifiedBy",
                table: "Language",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedUTC",
                table: "Language",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "ExceptionLog",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedUTC",
                table: "ExceptionLog",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "LastModifiedBy",
                table: "ExceptionLog",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedUTC",
                table: "ExceptionLog",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "CustomerRoles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedUTC",
                table: "CustomerRoles",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "LastModifiedBy",
                table: "CustomerRoles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedUTC",
                table: "CustomerRoles",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "CustomerRoleActions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedUTC",
                table: "CustomerRoleActions",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "LastModifiedBy",
                table: "CustomerRoleActions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedUTC",
                table: "CustomerRoleActions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Client",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedUTC",
                table: "Client",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "LastModifiedBy",
                table: "Client",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedUTC",
                table: "Client",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Action",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedUTC",
                table: "Action",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "LastModifiedBy",
                table: "Action",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedUTC",
                table: "Action",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "UserInRoles");

            migrationBuilder.DropColumn(
                name: "CreatedUTC",
                table: "UserInRoles");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "UserInRoles");

            migrationBuilder.DropColumn(
                name: "LastModifiedUTC",
                table: "UserInRoles");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "User");

            migrationBuilder.DropColumn(
                name: "CreatedUTC",
                table: "User");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "User");

            migrationBuilder.DropColumn(
                name: "LastModifiedUTC",
                table: "User");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "CreatedUTC",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "LastModifiedUTC",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "CreatedUTC",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "LastModifiedUTC",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "SystemRoles");

            migrationBuilder.DropColumn(
                name: "CreatedUTC",
                table: "SystemRoles");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "SystemRoles");

            migrationBuilder.DropColumn(
                name: "LastModifiedUTC",
                table: "SystemRoles");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "SystemRoleActions");

            migrationBuilder.DropColumn(
                name: "CreatedUTC",
                table: "SystemRoleActions");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "SystemRoleActions");

            migrationBuilder.DropColumn(
                name: "LastModifiedUTC",
                table: "SystemRoleActions");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "SystemInformation");

            migrationBuilder.DropColumn(
                name: "CreatedUTC",
                table: "SystemInformation");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "SystemInformation");

            migrationBuilder.DropColumn(
                name: "LastModifiedUTC",
                table: "SystemInformation");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "SpendTimes");

            migrationBuilder.DropColumn(
                name: "CreatedUTC",
                table: "SpendTimes");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "SpendTimes");

            migrationBuilder.DropColumn(
                name: "LastModifiedUTC",
                table: "SpendTimes");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "RunningTasks");

            migrationBuilder.DropColumn(
                name: "CreatedUTC",
                table: "RunningTasks");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "RunningTasks");

            migrationBuilder.DropColumn(
                name: "LastModifiedUTC",
                table: "RunningTasks");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "CreatedUTC",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "LastModifiedUTC",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "LocaleStringResource");

            migrationBuilder.DropColumn(
                name: "CreatedUTC",
                table: "LocaleStringResource");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "LocaleStringResource");

            migrationBuilder.DropColumn(
                name: "LastModifiedUTC",
                table: "LocaleStringResource");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Language");

            migrationBuilder.DropColumn(
                name: "CreatedUTC",
                table: "Language");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Language");

            migrationBuilder.DropColumn(
                name: "LastModifiedUTC",
                table: "Language");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ExceptionLog");

            migrationBuilder.DropColumn(
                name: "CreatedUTC",
                table: "ExceptionLog");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "ExceptionLog");

            migrationBuilder.DropColumn(
                name: "LastModifiedUTC",
                table: "ExceptionLog");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "CustomerRoles");

            migrationBuilder.DropColumn(
                name: "CreatedUTC",
                table: "CustomerRoles");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "CustomerRoles");

            migrationBuilder.DropColumn(
                name: "LastModifiedUTC",
                table: "CustomerRoles");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "CustomerRoleActions");

            migrationBuilder.DropColumn(
                name: "CreatedUTC",
                table: "CustomerRoleActions");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "CustomerRoleActions");

            migrationBuilder.DropColumn(
                name: "LastModifiedUTC",
                table: "CustomerRoleActions");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "CreatedUTC",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "LastModifiedUTC",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Action");

            migrationBuilder.DropColumn(
                name: "CreatedUTC",
                table: "Action");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Action");

            migrationBuilder.DropColumn(
                name: "LastModifiedUTC",
                table: "Action");
        }
    }
}

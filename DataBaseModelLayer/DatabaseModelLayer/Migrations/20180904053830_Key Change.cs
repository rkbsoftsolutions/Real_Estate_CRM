using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM.DatabaseModelLayer.Migrations
{
    public partial class KeyChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MouelsRolesLink_ApplicationRoles_applicationRolesId",
                table: "MouelsRolesLink");

            migrationBuilder.DropForeignKey(
                name: "FK_MouelsRolesLink_ApplicationModules_application_ModulesId",
                table: "MouelsRolesLink");

            migrationBuilder.DropIndex(
                name: "IX_MouelsRolesLink_applicationRolesId",
                table: "MouelsRolesLink");

            migrationBuilder.DropIndex(
                name: "IX_MouelsRolesLink_application_ModulesId",
                table: "MouelsRolesLink");

            migrationBuilder.DropColumn(
                name: "applicationRolesId",
                table: "MouelsRolesLink");

            migrationBuilder.DropColumn(
                name: "application_ModulesId",
                table: "MouelsRolesLink");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalProjectArea",
                table: "Project_Master",
                type: "decimal(12, 0)",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "GoalSellingAmount",
                table: "Project_Master",
                type: "decimal(12, 0)",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.CreateIndex(
                name: "IX_MouelsRolesLink_Application_Modules_Id",
                table: "MouelsRolesLink",
                column: "Application_Modules_Id");

            migrationBuilder.CreateIndex(
                name: "IX_MouelsRolesLink_Application_Roles_Id",
                table: "MouelsRolesLink",
                column: "Application_Roles_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MouelsRolesLink_ApplicationModules_Application_Modules_Id",
                table: "MouelsRolesLink",
                column: "Application_Modules_Id",
                principalTable: "ApplicationModules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MouelsRolesLink_ApplicationRoles_Application_Roles_Id",
                table: "MouelsRolesLink",
                column: "Application_Roles_Id",
                principalTable: "ApplicationRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MouelsRolesLink_ApplicationModules_Application_Modules_Id",
                table: "MouelsRolesLink");

            migrationBuilder.DropForeignKey(
                name: "FK_MouelsRolesLink_ApplicationRoles_Application_Roles_Id",
                table: "MouelsRolesLink");

            migrationBuilder.DropIndex(
                name: "IX_MouelsRolesLink_Application_Modules_Id",
                table: "MouelsRolesLink");

            migrationBuilder.DropIndex(
                name: "IX_MouelsRolesLink_Application_Roles_Id",
                table: "MouelsRolesLink");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalProjectArea",
                table: "Project_Master",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(12, 0)");

            migrationBuilder.AlterColumn<decimal>(
                name: "GoalSellingAmount",
                table: "Project_Master",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(12, 0)");

            migrationBuilder.AddColumn<Guid>(
                name: "applicationRolesId",
                table: "MouelsRolesLink",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "application_ModulesId",
                table: "MouelsRolesLink",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MouelsRolesLink_applicationRolesId",
                table: "MouelsRolesLink",
                column: "applicationRolesId");

            migrationBuilder.CreateIndex(
                name: "IX_MouelsRolesLink_application_ModulesId",
                table: "MouelsRolesLink",
                column: "application_ModulesId");

            migrationBuilder.AddForeignKey(
                name: "FK_MouelsRolesLink_ApplicationRoles_applicationRolesId",
                table: "MouelsRolesLink",
                column: "applicationRolesId",
                principalTable: "ApplicationRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MouelsRolesLink_ApplicationModules_application_ModulesId",
                table: "MouelsRolesLink",
                column: "application_ModulesId",
                principalTable: "ApplicationModules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

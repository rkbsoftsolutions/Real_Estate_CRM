using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM.DatabaseModelLayer.Migrations
{
    public partial class CRM_Base : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationModules",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ShortDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationModules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NormalizedName = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUserRole",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false),
                    ApplicationUserRoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserRole", x => x.ApplicationUserRoleId);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Project_Master",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ShortDescription = table.Column<string>(nullable: true),
                    Units_Types = table.Column<int>(nullable: false),
                    StartSellingDate = table.Column<DateTime>(nullable: false),
                    EndSellingDate = table.Column<DateTime>(nullable: false),
                    GoalSellingAmount = table.Column<decimal>(nullable: false),
                    TotalProjectArea = table.Column<decimal>(nullable: false),
                    AreaLength = table.Column<decimal>(nullable: false),
                    AreaWidth = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project_Master", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MouelsRolesLink",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Application_Modules_Id = table.Column<Guid>(nullable: false),
                    Application_Roles_Id = table.Column<Guid>(nullable: false),
                    application_ModulesId = table.Column<Guid>(nullable: true),
                    applicationRolesId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MouelsRolesLink", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MouelsRolesLink_ApplicationRoles_applicationRolesId",
                        column: x => x.applicationRolesId,
                        principalTable: "ApplicationRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MouelsRolesLink_ApplicationModules_application_ModulesId",
                        column: x => x.application_ModulesId,
                        principalTable: "ApplicationModules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AssetMasters",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    AssetType = table.Column<int>(nullable: false),
                    AssetLink = table.Column<string>(nullable: true),
                    Project_MasterId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetMasters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssetMasters_Project_Master_Project_MasterId",
                        column: x => x.Project_MasterId,
                        principalTable: "Project_Master",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BuildingPlanMasters",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ShortDescription = table.Column<string>(nullable: true),
                    Units_Types = table.Column<int>(nullable: false),
                    Project_Master_Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingPlanMasters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuildingPlanMasters_Project_Master_Project_Master_Id",
                        column: x => x.Project_Master_Id,
                        principalTable: "Project_Master",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssetMasters_Project_MasterId",
                table: "AssetMasters",
                column: "Project_MasterId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildingPlanMasters_Project_Master_Id",
                table: "BuildingPlanMasters",
                column: "Project_Master_Id");

            migrationBuilder.CreateIndex(
                name: "IX_MouelsRolesLink_applicationRolesId",
                table: "MouelsRolesLink",
                column: "applicationRolesId");

            migrationBuilder.CreateIndex(
                name: "IX_MouelsRolesLink_application_ModulesId",
                table: "MouelsRolesLink",
                column: "application_ModulesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserRole");

            migrationBuilder.DropTable(
                name: "ApplicationUsers");

            migrationBuilder.DropTable(
                name: "AssetMasters");

            migrationBuilder.DropTable(
                name: "BuildingPlanMasters");

            migrationBuilder.DropTable(
                name: "MouelsRolesLink");

            migrationBuilder.DropTable(
                name: "Project_Master");

            migrationBuilder.DropTable(
                name: "ApplicationRoles");

            migrationBuilder.DropTable(
                name: "ApplicationModules");
        }
    }
}

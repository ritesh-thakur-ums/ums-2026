using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UMS.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "project");

            migrationBuilder.EnsureSchema(
                name: "auth");

            migrationBuilder.CreateTable(
                name: "avRoles",
                schema: "auth",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_avRoles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "avUsers",
                schema: "auth",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_avUsers", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "avProject",
                schema: "project",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_avProject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_avProject_avUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalSchema: "auth",
                        principalTable: "avUsers",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "avUserRoles",
                schema: "auth",
                columns: table => new
                {
                    UserRoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_avUserRoles", x => x.UserRoleId);
                    table.ForeignKey(
                        name: "FK_avUserRoles_avRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "auth",
                        principalTable: "avRoles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_avUserRoles_avUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "auth",
                        principalTable: "avUsers",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "avProjectMember",
                schema: "project",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_avProjectMember", x => x.Id);
                    table.ForeignKey(
                        name: "FK_avProjectMember_avProject_ProjectId",
                        column: x => x.ProjectId,
                        principalSchema: "project",
                        principalTable: "avProject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_avProjectMember_avUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "auth",
                        principalTable: "avUsers",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_avProject_OwnerId",
                schema: "project",
                table: "avProject",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_avProjectMember_ProjectId",
                schema: "project",
                table: "avProjectMember",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_avProjectMember_UserId",
                schema: "project",
                table: "avProjectMember",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_avUserRoles_RoleId",
                schema: "auth",
                table: "avUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_avUserRoles_UserId",
                schema: "auth",
                table: "avUserRoles",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "avProjectMember",
                schema: "project");

            migrationBuilder.DropTable(
                name: "avUserRoles",
                schema: "auth");

            migrationBuilder.DropTable(
                name: "avProject",
                schema: "project");

            migrationBuilder.DropTable(
                name: "avRoles",
                schema: "auth");

            migrationBuilder.DropTable(
                name: "avUsers",
                schema: "auth");
        }
    }
}

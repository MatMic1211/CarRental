using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Pointman.CarRental.Company.API.Migrations
{
    /// <inheritdoc />
    public partial class userseederdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPermissions_UserRoles_UserRoleId",
                table: "UserPermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Users_UserId",
                table: "UserRoles");

            migrationBuilder.DropIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles");

            migrationBuilder.DropIndex(
                name: "IX_UserPermissions_UserRoleId",
                table: "UserPermissions");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "UserRoleId",
                table: "UserPermissions");

            migrationBuilder.CreateTable(
                name: "UserRolePermissions",
                columns: table => new
                {
                    UserRoleId = table.Column<int>(type: "int", nullable: false),
                    UserPermissionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRolePermissions", x => new { x.UserRoleId, x.UserPermissionId });
                    table.ForeignKey(
                        name: "FK_UserRolePermissions_UserPermissions_UserPermissionId",
                        column: x => x.UserPermissionId,
                        principalTable: "UserPermissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRolePermissions_UserRoles_UserRoleId",
                        column: x => x.UserRoleId,
                        principalTable: "UserRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserRoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserUserRoles", x => new { x.UserId, x.UserRoleId });
                    table.ForeignKey(
                        name: "FK_UserUserRoles_UserRoles_UserRoleId",
                        column: x => x.UserRoleId,
                        principalTable: "UserRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserUserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "UserPermissions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "ADD_USERS" },
                    { 2, "ADD_COMP" },
                    { 3, "EDI_COMP" },
                    { 4, "DEL_COMP" },
                    { 5, "ADD_CARS" },
                    { 6, "VI_RESER" },
                    { 7, "MK_RESER" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "CompanyOwner" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "mateusz@example.com", "Mateusz", "Miczulski" },
                    { 2, "piotr@example.com", "Piotr", "Miczulski" }
                });

            migrationBuilder.InsertData(
                table: "UserRolePermissions",
                columns: new[] { "UserPermissionId", "UserRoleId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 1 },
                    { 5, 2 },
                    { 6, 2 },
                    { 7, 2 }
                });

            migrationBuilder.InsertData(
                table: "UserUserRoles",
                columns: new[] { "UserId", "UserRoleId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRolePermissions_UserPermissionId",
                table: "UserRolePermissions",
                column: "UserPermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserUserRoles_UserRoleId",
                table: "UserUserRoles",
                column: "UserRoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRolePermissions");

            migrationBuilder.DropTable(
                name: "UserUserRoles");

            migrationBuilder.DeleteData(
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "UserPermissions",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "UserRoles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserRoleId",
                table: "UserPermissions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPermissions_UserRoleId",
                table: "UserPermissions",
                column: "UserRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPermissions_UserRoles_UserRoleId",
                table: "UserPermissions",
                column: "UserRoleId",
                principalTable: "UserRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Users_UserId",
                table: "UserRoles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

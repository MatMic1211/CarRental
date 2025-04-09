using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Pointman.CarRental.Company.API.Migrations
{
    /// <inheritdoc />
    public partial class UserRegistration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRolePermissions",
                keyColumns: new[] { "UserPermissionId", "UserRoleId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "UserRolePermissions",
                keyColumns: new[] { "UserPermissionId", "UserRoleId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "UserRolePermissions",
                keyColumns: new[] { "UserPermissionId", "UserRoleId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "UserRolePermissions",
                keyColumns: new[] { "UserPermissionId", "UserRoleId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "UserRolePermissions",
                keyColumns: new[] { "UserPermissionId", "UserRoleId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "UserRolePermissions",
                keyColumns: new[] { "UserPermissionId", "UserRoleId" },
                keyValues: new object[] { 6, 2 });

            migrationBuilder.DeleteData(
                table: "UserRolePermissions",
                keyColumns: new[] { "UserPermissionId", "UserRoleId" },
                keyValues: new object[] { 7, 2 });

            migrationBuilder.DeleteData(
                table: "UserUserRoles",
                keyColumns: new[] { "UserId", "UserRoleId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "UserUserRoles",
                keyColumns: new[] { "UserId", "UserRoleId" },
                keyValues: new object[] { 2, 2 });

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}

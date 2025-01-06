using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Pointman.CarRental.Company.API.Migrations
{
    /// <inheritdoc />
    public partial class back : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_RentCompanies_RentCompanyId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_RentCompanyId",
                table: "Cars");

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RentCompanies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RentCompanies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "RentCompanyId",
                table: "Cars");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RentCompanyId",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "RentCompanies",
                columns: new[] { "Id", "Name", "TelephoneNumber" },
                values: new object[,]
                {
                    { 1, "Premium Rentals", "123456789" },
                    { 2, "Budget Rentals", "987654321" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Brand", "Model", "RentCompanyId" },
                values: new object[,]
                {
                    { 1, "Tesla", "Model S", 1 },
                    { 2, "Ford", "Mustang", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_RentCompanyId",
                table: "Cars",
                column: "RentCompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_RentCompanies_RentCompanyId",
                table: "Cars",
                column: "RentCompanyId",
                principalTable: "RentCompanies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

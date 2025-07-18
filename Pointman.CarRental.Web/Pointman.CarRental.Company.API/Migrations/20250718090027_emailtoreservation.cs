using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pointman.CarRental.Company.API.Migrations
{
    /// <inheritdoc />
    public partial class emailtoreservation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Reservations");
        }
    }
}

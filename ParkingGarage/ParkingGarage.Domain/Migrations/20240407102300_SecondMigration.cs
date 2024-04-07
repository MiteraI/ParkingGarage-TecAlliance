using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkingGarage.Domain.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SlotCode",
                table: "parking_slot",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FloorCode",
                table: "floor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SlotCode",
                table: "parking_slot");

            migrationBuilder.DropColumn(
                name: "FloorCode",
                table: "floor");
        }
    }
}

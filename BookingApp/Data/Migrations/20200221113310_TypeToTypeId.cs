using Microsoft.EntityFrameworkCore.Migrations;

namespace Booking.App.Migrations
{
    public partial class TypeToTypeId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Events");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "SeatPrices",
                type: "decimal(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Events",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Events");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "SeatPrices",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 2)");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace Booking.DataAccess.Migrations
{
    public partial class SeatStatusAllNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SeatStatuses_SeatId",
                table: "SeatStatuses");

            migrationBuilder.AlterColumn<int>(
                name: "SeatId",
                table: "SeatStatuses",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PriceId",
                table: "SeatStatuses",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EventId",
                table: "SeatStatuses",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_SeatStatuses_SeatId",
                table: "SeatStatuses",
                column: "SeatId",
                unique: true,
                filter: "[SeatId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SeatStatuses_SeatId",
                table: "SeatStatuses");

            migrationBuilder.AlterColumn<int>(
                name: "SeatId",
                table: "SeatStatuses",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PriceId",
                table: "SeatStatuses",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EventId",
                table: "SeatStatuses",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SeatStatuses_SeatId",
                table: "SeatStatuses",
                column: "SeatId",
                unique: true);
        }
    }
}

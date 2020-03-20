using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Booking.DataAccess.Migrations
{
    public partial class Bookings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Available",
                table: "SeatStatuses",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bool",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SeatId",
                table: "SeatStatuses",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PriceId",
                table: "SeatStatuses",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EventId",
                table: "SeatStatuses",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    BookingId = table.Column<Guid>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    BookingDate = table.Column<DateTime>(nullable: false),
                    StatusId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_Bookings_SeatStatuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "SeatStatuses",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_StatusId",
                table: "Bookings",
                column: "StatusId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.AlterColumn<int>(
                name: "SeatId",
                table: "SeatStatuses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "PriceId",
                table: "SeatStatuses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "EventId",
                table: "SeatStatuses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingApp.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "event_types",
                columns: table => new
                {
                    type = table.Column<string>(fixedLength: true, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("event_types_pk", x => x.type);
                });

            migrationBuilder.CreateTable(
                name: "place",
                columns: table => new
                {
                    PlaceId = table.Column<int>(nullable: false),
                    name = table.Column<string>(fixedLength: true, maxLength: 30, nullable: false),
                    maximum_capacity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_place", x => x.PlaceId);
                });

            migrationBuilder.CreateTable(
                name: "ref_seat_status",
                columns: table => new
                {
                    StatusId = table.Column<int>(nullable: false),
                    StatusDescription = table.Column<string>(fixedLength: true, maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ref_seat_status_pk", x => x.StatusId);
                });

            migrationBuilder.CreateTable(
                name: "event",
                columns: table => new
                {
                    EventId = table.Column<int>(nullable: false),
                    name = table.Column<string>(fixedLength: true, maxLength: 50, nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    description = table.Column<string>(fixedLength: true, maxLength: 500, nullable: false),
                    place_PlaceId = table.Column<int>(nullable: true),
                    event_types_type = table.Column<string>(fixedLength: true, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_event", x => x.EventId);
                    table.ForeignKey(
                        name: "event_event_types_fk",
                        column: x => x.event_types_type,
                        principalTable: "event_types",
                        principalColumn: "type",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "event_place_fk",
                        column: x => x.place_PlaceId,
                        principalTable: "place",
                        principalColumn: "PlaceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "sectors",
                columns: table => new
                {
                    place_PlaceId = table.Column<int>(nullable: false),
                    sectornumber = table.Column<string>(fixedLength: true, maxLength: 3, nullable: false),
                    rowscount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("sectors_pk", x => new { x.sectornumber, x.place_PlaceId });
                    table.ForeignKey(
                        name: "sectors_place_fk",
                        column: x => x.place_PlaceId,
                        principalTable: "place",
                        principalColumn: "PlaceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "seat_prices",
                columns: table => new
                {
                    seattype = table.Column<string>(fixedLength: true, maxLength: 10, nullable: false),
                    price = table.Column<decimal>(type: "numeric(2, 0)", nullable: false),
                    event_EventId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("seat_prices_pk", x => x.seattype);
                    table.ForeignKey(
                        name: "seat_prices_event_fk",
                        column: x => x.event_EventId,
                        principalTable: "event",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rows",
                columns: table => new
                {
                    sectors_place_PlaceId = table.Column<int>(nullable: false),
                    RowNumber = table.Column<int>(nullable: false),
                    sectors_sectornumber = table.Column<string>(fixedLength: true, maxLength: 3, nullable: false),
                    seatcount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("rows_pk", x => new { x.RowNumber, x.sectors_sectornumber, x.sectors_place_PlaceId });
                    table.ForeignKey(
                        name: "rows_sectors_fk",
                        columns: x => new { x.sectors_sectornumber, x.sectors_place_PlaceId },
                        principalTable: "sectors",
                        principalColumns: new[] { "sectornumber", "place_PlaceId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "seats",
                columns: table => new
                {
                    seatnumber = table.Column<int>(nullable: false),
                    eventdate = table.Column<DateTime>(type: "date", nullable: false),
                    rows_RowNumber = table.Column<int>(nullable: false),
                    rows_sectors_sectornumber = table.Column<string>(fixedLength: true, maxLength: 3, nullable: false),
                    rows_sectors_place_PlaceId = table.Column<int>(nullable: false),
                    ref_seat_status_StatusId = table.Column<int>(nullable: false),
                    seat_prices_seattype = table.Column<string>(fixedLength: true, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("seats_pk", x => new { x.seatnumber, x.eventdate, x.rows_RowNumber, x.rows_sectors_sectornumber, x.rows_sectors_place_PlaceId });
                    table.ForeignKey(
                        name: "seats_ref_seat_status_fk",
                        column: x => x.ref_seat_status_StatusId,
                        principalTable: "ref_seat_status",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "seats_seat_prices_fk",
                        column: x => x.seat_prices_seattype,
                        principalTable: "seat_prices",
                        principalColumn: "seattype",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "seats_rows_fk",
                        columns: x => new { x.rows_RowNumber, x.rows_sectors_sectornumber, x.rows_sectors_place_PlaceId },
                        principalTable: "Rows",
                        principalColumns: new[] { "RowNumber", "sectors_sectornumber", "sectors_place_PlaceId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_event_event_types_type",
                table: "event",
                column: "event_types_type");

            migrationBuilder.CreateIndex(
                name: "IX_event_place_PlaceId",
                table: "event",
                column: "place_PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Rows_sectors_sectornumber_sectors_place_PlaceId",
                table: "Rows",
                columns: new[] { "sectors_sectornumber", "sectors_place_PlaceId" });

            migrationBuilder.CreateIndex(
                name: "IX_seat_prices_event_EventId",
                table: "seat_prices",
                column: "event_EventId");

            migrationBuilder.CreateIndex(
                name: "IX_seats_ref_seat_status_StatusId",
                table: "seats",
                column: "ref_seat_status_StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_seats_seat_prices_seattype",
                table: "seats",
                column: "seat_prices_seattype");

            migrationBuilder.CreateIndex(
                name: "IX_seats_rows_RowNumber_rows_sectors_sectornumber_rows_sectors_place_PlaceId",
                table: "seats",
                columns: new[] { "rows_RowNumber", "rows_sectors_sectornumber", "rows_sectors_place_PlaceId" });

            migrationBuilder.CreateIndex(
                name: "IX_sectors_place_PlaceId",
                table: "sectors",
                column: "place_PlaceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "seats");

            migrationBuilder.DropTable(
                name: "ref_seat_status");

            migrationBuilder.DropTable(
                name: "seat_prices");

            migrationBuilder.DropTable(
                name: "Rows");

            migrationBuilder.DropTable(
                name: "event");

            migrationBuilder.DropTable(
                name: "sectors");

            migrationBuilder.DropTable(
                name: "event_types");

            migrationBuilder.DropTable(
                name: "place");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Booking.App.Migrations
{
    public partial class InitialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventTypes",
                columns: table => new
                {
                    TypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTypes", x => x.TypeId);
                });

            migrationBuilder.CreateTable(
                name: "Places",
                columns: table => new
                {
                    PlaceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    MaximumCapacity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Places", x => x.PlaceId);
                });

            migrationBuilder.CreateTable(
                name: "RefSeatStatus",
                columns: table => new
                {
                    StatusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefSeatStatus", x => x.StatusId);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    PlaceId = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    TypeNavigationTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_Events_Places_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Places",
                        principalColumn: "PlaceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Events_EventTypes_TypeNavigationTypeId",
                        column: x => x.TypeNavigationTypeId,
                        principalTable: "EventTypes",
                        principalColumn: "TypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SeatPrices",
                columns: table => new
                {
                    SeatId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeatType = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    EventId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeatPrices", x => x.SeatId);
                    table.ForeignKey(
                        name: "FK_SeatPrices_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seats",
                columns: table => new
                {
                    SeatId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventDate = table.Column<DateTime>(nullable: true),
                    SeatType = table.Column<int>(nullable: true),
                    SeatNumber = table.Column<int>(nullable: false),
                    RowNumber = table.Column<int>(nullable: false),
                    SectorNumber = table.Column<string>(nullable: true),
                    PlaceId = table.Column<int>(nullable: false),
                    RefSeatStatusId = table.Column<int>(nullable: false),
                    SeatPricesSeatTypeNavigationSeatId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seats", x => x.SeatId);
                    table.ForeignKey(
                        name: "FK_Seats_Places_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Places",
                        principalColumn: "PlaceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Seats_RefSeatStatus_RefSeatStatusId",
                        column: x => x.RefSeatStatusId,
                        principalTable: "RefSeatStatus",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Seats_SeatPrices_SeatPricesSeatTypeNavigationSeatId",
                        column: x => x.SeatPricesSeatTypeNavigationSeatId,
                        principalTable: "SeatPrices",
                        principalColumn: "SeatId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_PlaceId",
                table: "Events",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_TypeNavigationTypeId",
                table: "Events",
                column: "TypeNavigationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SeatPrices_EventId",
                table: "SeatPrices",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_PlaceId",
                table: "Seats",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_RefSeatStatusId",
                table: "Seats",
                column: "RefSeatStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_SeatPricesSeatTypeNavigationSeatId",
                table: "Seats",
                column: "SeatPricesSeatTypeNavigationSeatId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Seats");

            migrationBuilder.DropTable(
                name: "RefSeatStatus");

            migrationBuilder.DropTable(
                name: "SeatPrices");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Places");

            migrationBuilder.DropTable(
                name: "EventTypes");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Booking.DataAccess.Migrations
{
    public partial class NumberOfSeats : Migration
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
                name: "SeatTypes",
                columns: table => new
                {
                    TypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeatTypes", x => x.TypeId);
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
                    NumberOfSeats = table.Column<int>(nullable: true),
                    AvailableSeats = table.Column<int>(nullable: true),
                    PlaceId = table.Column<int>(nullable: false),
                    TypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_Events_Places_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Places",
                        principalColumn: "PlaceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Events_EventTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "EventTypes",
                        principalColumn: "TypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Seats",
                columns: table => new
                {
                    SeatId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeId = table.Column<int>(nullable: false),
                    SeatNumber = table.Column<int>(nullable: false),
                    RowNumber = table.Column<int>(nullable: false),
                    SectorNumber = table.Column<int>(nullable: false),
                    PlaceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seats", x => x.SeatId);
                    table.ForeignKey(
                        name: "FK_Seats_Places_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Places",
                        principalColumn: "PlaceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Seats_SeatTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "SeatTypes",
                        principalColumn: "TypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SectorPrices",
                columns: table => new
                {
                    PriceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    EventId = table.Column<int>(nullable: false),
                    SectorNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectorPrices", x => x.PriceId);
                    table.ForeignKey(
                        name: "FK_SectorPrices_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SeatStatuses",
                columns: table => new
                {
                    StatusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Available = table.Column<bool>(nullable: true),
                    SeatId = table.Column<int>(nullable: false),
                    EventId = table.Column<int>(nullable: false),
                    PriceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeatStatuses", x => x.StatusId);
                    table.ForeignKey(
                        name: "FK_SeatStatuses_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SeatStatuses_SectorPrices_PriceId",
                        column: x => x.PriceId,
                        principalTable: "SectorPrices",
                        principalColumn: "PriceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SeatStatuses_Seats_SeatId",
                        column: x => x.SeatId,
                        principalTable: "Seats",
                        principalColumn: "SeatId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_PlaceId",
                table: "Events",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_TypeId",
                table: "Events",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_PlaceId",
                table: "Seats",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_TypeId",
                table: "Seats",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SeatStatuses_EventId",
                table: "SeatStatuses",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_SeatStatuses_PriceId",
                table: "SeatStatuses",
                column: "PriceId");

            migrationBuilder.CreateIndex(
                name: "IX_SeatStatuses_SeatId",
                table: "SeatStatuses",
                column: "SeatId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SectorPrices_EventId",
                table: "SectorPrices",
                column: "EventId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SeatStatuses");

            migrationBuilder.DropTable(
                name: "SectorPrices");

            migrationBuilder.DropTable(
                name: "Seats");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "SeatTypes");

            migrationBuilder.DropTable(
                name: "Places");

            migrationBuilder.DropTable(
                name: "EventTypes");
        }
    }
}

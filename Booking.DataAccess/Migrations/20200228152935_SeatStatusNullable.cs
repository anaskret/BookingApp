using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Booking.DataAccess.Migrations
{
    public partial class SeatStatusNullable : Migration
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
                name: "SeatStatuses",
                columns: table => new
                {
                    StatusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeatStatuses", x => x.StatusId);
                });

            migrationBuilder.CreateTable(
                name: "SeatTypes",
                columns: table => new
                {
                    SeatTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeatTypes", x => x.SeatTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Description = table.Column<string>(nullable: true),
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Events_EventTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "EventTypes",
                        principalColumn: "TypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SeatPrices",
                columns: table => new
                {
                    SeatPriceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeatType = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    EventId = table.Column<int>(nullable: false),
                    SeatTypesSeatTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeatPrices", x => x.SeatPriceId);
                    table.ForeignKey(
                        name: "FK_SeatPrices_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SeatPrices_SeatTypes_SeatTypesSeatTypeId",
                        column: x => x.SeatTypesSeatTypeId,
                        principalTable: "SeatTypes",
                        principalColumn: "SeatTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Seats",
                columns: table => new
                {
                    SeatId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventDate = table.Column<DateTime>(type: "date", nullable: true),
                    SeatType = table.Column<int>(nullable: true),
                    SeatStatusId = table.Column<int>(nullable: true),
                    SeatNumber = table.Column<int>(nullable: false),
                    RowNumber = table.Column<int>(nullable: false),
                    SectorNumber = table.Column<string>(nullable: true),
                    PlaceId = table.Column<int>(nullable: false),
                    SeatPricesSeatTypeNavigationSeatPriceId = table.Column<int>(nullable: true)
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
                        name: "FK_Seats_SeatPrices_SeatPricesSeatTypeNavigationSeatPriceId",
                        column: x => x.SeatPricesSeatTypeNavigationSeatPriceId,
                        principalTable: "SeatPrices",
                        principalColumn: "SeatPriceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Seats_SeatStatuses_SeatStatusId",
                        column: x => x.SeatStatusId,
                        principalTable: "SeatStatuses",
                        principalColumn: "StatusId",
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
                name: "IX_SeatPrices_EventId",
                table: "SeatPrices",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_SeatPrices_SeatTypesSeatTypeId",
                table: "SeatPrices",
                column: "SeatTypesSeatTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_PlaceId",
                table: "Seats",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_SeatPricesSeatTypeNavigationSeatPriceId",
                table: "Seats",
                column: "SeatPricesSeatTypeNavigationSeatPriceId");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_SeatStatusId",
                table: "Seats",
                column: "SeatStatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Seats");

            migrationBuilder.DropTable(
                name: "SeatPrices");

            migrationBuilder.DropTable(
                name: "SeatStatuses");

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

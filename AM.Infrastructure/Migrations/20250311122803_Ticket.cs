﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Ticket : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    PassengerFk = table.Column<string>(type: "nvarchar(7)", nullable: false),
                    FlightFk = table.Column<int>(type: "int", nullable: false),
                    Prix = table.Column<double>(type: "float", nullable: false),
                    Siege = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VIP = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => new { x.FlightFk, x.PassengerFk });
                    table.ForeignKey(
                        name: "FK_Tickets_Flights_FlightFk",
                        column: x => x.FlightFk,
                        principalTable: "Flights",
                        principalColumn: "FlightId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Passengers_PassengerFk",
                        column: x => x.PassengerFk,
                        principalTable: "Passengers",
                        principalColumn: "PassportNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_PassengerFk",
                table: "Tickets",
                column: "PassengerFk");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    PassengersPassportNumber = table.Column<string>(type: "nvarchar(7)", nullable: false),
                    flightsFlightId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => new { x.PassengersPassportNumber, x.flightsFlightId });
                    table.ForeignKey(
                        name: "FK_Reservations_Flights_flightsFlightId",
                        column: x => x.flightsFlightId,
                        principalTable: "Flights",
                        principalColumn: "FlightId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Passengers_PassengersPassportNumber",
                        column: x => x.PassengersPassportNumber,
                        principalTable: "Passengers",
                        principalColumn: "PassportNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_flightsFlightId",
                table: "Reservations",
                column: "flightsFlightId");
        }
    }
}

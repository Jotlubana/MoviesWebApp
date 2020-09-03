using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MoviesWebApp.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AddressModel",
                columns: table => new
                {
                    AddressId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(nullable: true),
                    PinCode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressModel", x => x.AddressId);
                });

            migrationBuilder.CreateTable(
                name: "MoviesModel",
                columns: table => new
                {
                    MovieId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieName = table.Column<string>(nullable: true),
                    Released = table.Column<DateTime>(nullable: false),
                    Genre = table.Column<string>(nullable: true),
                    Rating = table.Column<int>(nullable: false),
                    IsBlockBuster = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoviesModel", x => x.MovieId);
                });

            migrationBuilder.CreateTable(
                name: "UsersModel",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    AddressId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersModel", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_UsersModel_AddressModel_AddressId",
                        column: x => x.AddressId,
                        principalTable: "AddressModel",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RentalsModel",
                columns: table => new
                {
                    RentalsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    MovieId = table.Column<int>(nullable: false),
                    BookingDate = table.Column<DateTime>(nullable: false),
                    IsDeliveryAddress = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentalsModel", x => x.RentalsId);
                    table.ForeignKey(
                        name: "FK_RentalsModel_MoviesModel_MovieId",
                        column: x => x.MovieId,
                        principalTable: "MoviesModel",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RentalsModel_UsersModel_UserId",
                        column: x => x.UserId,
                        principalTable: "UsersModel",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RentalsModel_MovieId",
                table: "RentalsModel",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_RentalsModel_UserId",
                table: "RentalsModel",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersModel_AddressId",
                table: "UsersModel",
                column: "AddressId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RentalsModel");

            migrationBuilder.DropTable(
                name: "MoviesModel");

            migrationBuilder.DropTable(
                name: "UsersModel");

            migrationBuilder.DropTable(
                name: "AddressModel");
        }
    }
}

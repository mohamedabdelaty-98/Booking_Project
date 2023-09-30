using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Booking_Project.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HotelId",
                table: "ReservationRooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ReservationRooms_HotelId",
                table: "ReservationRooms",
                column: "HotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationRooms_Hotels_HotelId",
                table: "ReservationRooms",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReservationRooms_Hotels_HotelId",
                table: "ReservationRooms");

            migrationBuilder.DropIndex(
                name: "IX_ReservationRooms_HotelId",
                table: "ReservationRooms");

            migrationBuilder.DropColumn(
                name: "HotelId",
                table: "ReservationRooms");
        }
    }
}

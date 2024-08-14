using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LCHB_BookingsMng.Migrations
{
    /// <inheritdoc />
    public partial class NewDbUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_BookingsService_BookingServiceNavBookingServiceId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_RoomServices_RoomServiceId",
                table: "Bookings");

            migrationBuilder.DropTable(
                name: "Bills");

            migrationBuilder.DropTable(
                name: "BookingsService");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_BookingServiceNavBookingServiceId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "RoomStatuses");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "RoomServices");

            migrationBuilder.DropColumn(
                name: "BookingDuration",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "BookingServiceNavBookingServiceId",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "RoomBookingServiceId",
                table: "Bookings",
                newName: "StatusPaymentId");

            migrationBuilder.AlterColumn<decimal>(
                name: "FeePerNight",
                table: "RoomTypes",
                type: "decimal(8,3)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(8,2)");

            migrationBuilder.AlterColumn<int>(
                name: "RoomServiceId",
                table: "Bookings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "StatusPayments",
                columns: table => new
                {
                    PaymentStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusPayments", x => x.PaymentStatusId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_StatusPaymentId",
                table: "Bookings",
                column: "StatusPaymentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_RoomServices_RoomServiceId",
                table: "Bookings",
                column: "RoomServiceId",
                principalTable: "RoomServices",
                principalColumn: "RoomServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_StatusPayments_StatusPaymentId",
                table: "Bookings",
                column: "StatusPaymentId",
                principalTable: "StatusPayments",
                principalColumn: "PaymentStatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_RoomServices_RoomServiceId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_StatusPayments_StatusPaymentId",
                table: "Bookings");

            migrationBuilder.DropTable(
                name: "StatusPayments");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_StatusPaymentId",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "StatusPaymentId",
                table: "Bookings",
                newName: "RoomBookingServiceId");

            migrationBuilder.AlterColumn<decimal>(
                name: "FeePerNight",
                table: "RoomTypes",
                type: "decimal(8,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(8,3)");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "RoomStatuses",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "RoomServices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "RoomServiceId",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BookingDuration",
                table: "Bookings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BookingServiceNavBookingServiceId",
                table: "Bookings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BookingsService",
                columns: table => new
                {
                    BookingServiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    RoomServiceId = table.Column<int>(type: "int", nullable: false),
                    BookingSVDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Request = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingsService", x => x.BookingServiceId);
                    table.ForeignKey(
                        name: "FK_BookingsService_RoomServices_RoomServiceId",
                        column: x => x.RoomServiceId,
                        principalTable: "RoomServices",
                        principalColumn: "RoomServiceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingsService_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PayId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PayStatus = table.Column<int>(type: "int", nullable: true),
                    PaymentCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PayId);
                });

            migrationBuilder.CreateTable(
                name: "Bills",
                columns: table => new
                {
                    BillId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingRoomId = table.Column<int>(type: "int", nullable: false),
                    BookingServiceId = table.Column<int>(type: "int", nullable: true),
                    PaymentNavPayId = table.Column<int>(type: "int", nullable: true),
                    PayId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.BillId);
                    table.ForeignKey(
                        name: "FK_Bills_BookingsService_BookingServiceId",
                        column: x => x.BookingServiceId,
                        principalTable: "BookingsService",
                        principalColumn: "BookingServiceId");
                    table.ForeignKey(
                        name: "FK_Bills_Bookings_BookingRoomId",
                        column: x => x.BookingRoomId,
                        principalTable: "Bookings",
                        principalColumn: "BookingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bills_Payments_PaymentNavPayId",
                        column: x => x.PaymentNavPayId,
                        principalTable: "Payments",
                        principalColumn: "PayId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_BookingServiceNavBookingServiceId",
                table: "Bookings",
                column: "BookingServiceNavBookingServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_BookingRoomId",
                table: "Bills",
                column: "BookingRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_BookingServiceId",
                table: "Bills",
                column: "BookingServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_PaymentNavPayId",
                table: "Bills",
                column: "PaymentNavPayId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingsService_RoomId",
                table: "BookingsService",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingsService_RoomServiceId",
                table: "BookingsService",
                column: "RoomServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_BookingsService_BookingServiceNavBookingServiceId",
                table: "Bookings",
                column: "BookingServiceNavBookingServiceId",
                principalTable: "BookingsService",
                principalColumn: "BookingServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_RoomServices_RoomServiceId",
                table: "Bookings",
                column: "RoomServiceId",
                principalTable: "RoomServices",
                principalColumn: "RoomServiceId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorAppMasterCrud.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Appointment",
                columns: table => new
                {
                    Appointment_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Appointment_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment", x => x.Appointment_ID);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    Service_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Service_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Appointment_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Service_Fee = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.Service_ID);
                    table.ForeignKey(
                        name: "FK_Service_Appointment_Appointment_ID",
                        column: x => x.Appointment_ID,
                        principalTable: "Appointment",
                        principalColumn: "Appointment_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Service_Appointment_ID",
                table: "Service",
                column: "Appointment_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "Appointment");
        }
    }
}
